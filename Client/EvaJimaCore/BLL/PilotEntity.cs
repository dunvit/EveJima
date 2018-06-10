using System;
using System.Drawing;
using System.Net;
using System.Threading.Tasks;
using System.Timers;
using EvaJimaCore;
using log4net;

namespace EveJimaCore.BLL
{
    public delegate void DelegateChangeSolarSystem(PilotEntity pilot, string systemFrom, string systemTo);
    public delegate void DelegateEnterToSolarSystem(string pilotName, string systemFrom, string systemTo);
    

    public class PilotEntity
    {
        private static readonly ILog Log = LogManager.GetLogger("All");

        public DelegateChangeSolarSystem OnChangeSolarSystem;
        
        public event DelegateEnterToSolarSystem OnEnterToSolarSystem;

        public string Key { get; set; }

        public long Id { get; set; }

        public string Name { get; set; }

        public Image Portrait { get; set; }

        public Map.Map SpaceMap { get; set; }

        public EveJimaUniverse.System Location { get; set; }

        public string SelectedSolarSystem { get; set; }

        //public CrestAuthorization CrestData { get; set; }
        public EsiAuthorization EsiData { get; set; }

        private DateTime _lastTokenUpdate;

        public PilotEntity(string id, string refreshToken)
        {
            ReInitialization(id, refreshToken);

            ActivatePilot();
        }

        public PilotEntity(string token)
        {
            Initialization(token);

            ActivatePilot();
        }

        private Timer _updateMapTimer;

        private void ActivatePilot()
        {
            Key = Global.ApplicationSettings.GetPilotKey(Name);

            LocationCurrentSystemName = Location.Name;

            // Pilot not are log in
            if (Location.Name == "unknown") return;


            _updateMapTimer = new Timer();
            _updateMapTimer.Elapsed += Event_Refresh;
            _updateMapTimer.Interval = 5000;
            _updateMapTimer.Enabled = true;

            if (Global.ApplicationSettings.IsUseMap == false) return;


            SpaceMap = new Map.Map { Key = Key, ActivePilot = Name, SelectedSolarSystemName = Location.Name };
            
            SpaceMap.OnChangeStatus += GetMapMessage;

            

            SpaceMap.Activate(Name, Location.Name);

            SpaceMap.ApiPublishSolarSystem(Name, Key, null, LocationCurrentSystemName);

            OnEnterToSolarSystem += SpaceMap.RelocatePilot;

            if (SpaceMap != null) ChangeLocation();

            
        }

        private void GetMapMessage(string message)
        {
            Log.Info(message);
        }

        private bool _loadingData;

        public void RefreshLocationInformation()
        {
            if(_loadingData) return;

            _loadingData = true;

            try
            {
                LoadLocationInfo();
            }
            catch
            {
                // ignored
            }

            _loadingData = false;
        }

        private void Event_Refresh(object sender, ElapsedEventArgs e)
        {
            RefreshPilotInfo();
        }

        private void RefreshPilotInfo()
        {
            Task.Run(() =>
            {
                RefreshInfo();
            });

            if (Global.Pilots.Selected.Name == Name && Global.ApplicationSettings.IsUseMap)
            {
                Task.Run(() =>
                {
                    UpdateMap();
                });
            }
        }

        private void UpdateMap()
        {
            Log.DebugFormat($"[Pilot.UpdateMap] starting update map for pilot for id = {Id} name= {Name} location {Location.Name}");

            if (Location.Name == "unknown") return;

            Global.MapApiFunctions.UpdateMap(SpaceMap);
        }

        public string RefreshToken { get; set; }

        public string LocationCurrentSystemName { get; set; }

        public string LocationPreviousSystemName { get; set; }

        private void ReInitialization(string id, string refreshToken)
        {
            Log.DebugFormat("[Pilot.ReInitialization] starting for id = {0} refreshToken = {1}", id, refreshToken);

            //CrestData = new CrestAuthorization(refreshToken, Global.Settings.CCPSSO_AUTH_CLIENT_ID, Global.Settings.CCPSSO_AUTH_CLIENT_SECRET);

            //CrestData.Refresh(refreshToken);

            //dynamic data = CrestData.ObtainingCharacterData();

            EsiData = new EsiAuthorization(Global.ApplicationSettings.Authorization_ClientId, Global.ApplicationSettings.Authorization_ClientSecret);

            EsiData.Refresh(refreshToken);

            dynamic data = EsiData.ObtainingCharacterData();

            Id = data.CharacterID;
            Name = data.CharacterName;

            LoadLocationInfo();

            LoadCharacterInfo();

            _lastTokenUpdate = DateTime.Now;
        }

        private void Initialization(string token)
        {
            Log.DebugFormat("[Pilot.Initialization] starting for token = {0}", token);

            EsiData = new EsiAuthorization(Global.ApplicationSettings.Authorization_ClientId, Global.ApplicationSettings.Authorization_ClientSecret);
            EsiData.Authorization(token);

            RefreshToken = EsiData.RefreshToken;

            dynamic data = EsiData.ObtainingCharacterData();

            Id = data.CharacterID;
            Name = data.CharacterName;

            LoadLocationInfo();

            if(Key == null) Key = Name + "'s map"; 

            if(Location.Name != "unknown")
            {
                SpaceMap = new Map.Map { Key = Key, ActivePilot = Name, SelectedSolarSystemName = Location.Name };

                SpaceMap.Activate(Name, Location.Name);

                SpaceMap.ApiPublishSolarSystem(Name, Key, null, LocationCurrentSystemName);

                OnEnterToSolarSystem += SpaceMap.RelocatePilot;
            }

            LoadCharacterInfo();

            Global.ApplicationSettings.UpdatePilotInStorage(Name, Id.ToString(), EsiData.RefreshToken, Key);

            _lastTokenUpdate = DateTime.Now;

        }

        private void LoadCharacterInfo()
        {
            Log.DebugFormat("[Pilot.LoadCharacterInfo] starting for Id = {0}", Id);

            try
            {
                var portraitAddress = EsiData.GetCharacterInfo(Id)["64x64"].ToString();

                var request = WebRequest.Create(portraitAddress);

                using (var response = request.GetResponse())
                using (var stream = response.GetResponseStream())
                {
                    Portrait = Image.FromStream(stream);
                }
            }
            catch(Exception ex)
            {
                Log.ErrorFormat("[PilotEntity.LoadCharacterInfo] Critical error = {0}", ex);
            }

            
        }

        private void LoadLocationInfo()
        {
            Log.DebugFormat("[Pilot.LoadLocationInfo] starting for Id = {0}", Id);

            _isBusy = true;

            var isNeedChangeLocation = false;

            try
            {
                if (Location == null)
                {
                    Location = new EveJimaUniverse.System();
                }

                Log.DebugFormat("[Pilot {0}] Call CrestData.GetLocation with ID={1}", Name, Id);

                dynamic locationInfo = EsiData.GetLocation(Id);

                var systemId = locationInfo.solar_system_id.ToString();

                dynamic solarSystemInfo = EsiData.GetSolarSystemInfo(systemId);

                var systemName = solarSystemInfo.name.ToString();

                if (Location.Name == systemName)
                {
                    Log.DebugFormat("[Pilot {0}] No need change location {1}", Name, Location.Name);
                    return;
                }

                if (!string.IsNullOrEmpty(systemId))
                {
                    if (LocationCurrentSystemName != systemName)
                    {
                        LocationPreviousSystemName = LocationCurrentSystemName;
                        LocationCurrentSystemName = systemName;

                        isNeedChangeLocation = true;
                    }

                }

                if (Global.Space.GetSystemByName(systemName) != null)
                {
                    var location = Global.Space.GetSystemByName(systemName);

                    Location = location.Clone() as EveJimaUniverse.System;

                    if (Location != null)
                    {
                        Location.Id = systemId;
                    }
                }
                else
                {
                    Location.Region = "";
                    Location.Constelation = "";
                    Location.Effect = "";
                    Location.Class = "";
                    Location.Static2 = "";
                    Location.Static = "";

                    Location.Id = systemId;

                    Location.Name = systemName;

                }

                if ( isNeedChangeLocation )
                {
                    ChangeLocation();
                }

            }
            catch (Exception ex)
            {
                Log.DebugFormat("[Pilot.LoadLocationInfo] pilot Id = {0} not login in game. Exception {1}", Id, ex);

                if (Location != null)
                {
                    Location.Name = "unknown";
                }
            }
            finally
            {
                _isBusy = false;
            }
        }

        private bool _isBusy;

        private void RefreshInfo()
        {
            Log.DebugFormat("[Pilot.RefreshInfo] starting for Id = {0}", Id);

            var span = DateTime.Now - _lastTokenUpdate;
            var ms = (int)span.TotalMilliseconds;

            if (ms > EsiData.ExpiresIn * 1000 - 20000)
            {
                EsiData.Refresh();

                _lastTokenUpdate = DateTime.Now;

                Log.DebugFormat("[Pilot.RefreshInfo] set LastTokenUpdate for Id = {0}", Id);
            }

            if (_isBusy == false)
            {
                Log.DebugFormat("[Pilot '{0}'] Load location info.", Name);
                LoadLocationInfo();
            }
        }


        public void ChangeLocation()
        {
            if (Key == null) return;

            Log.InfoFormat("[Pilot '{3}'] Publish system with key {0} from {1} to {2} ", Name, LocationPreviousSystemName, LocationCurrentSystemName, Name);

            if(Global.ApplicationSettings.IsUseMap)
                SpaceMap.Publish(Name, LocationPreviousSystemName, LocationCurrentSystemName);

            if (OnChangeSolarSystem == null) return;

            Log.InfoFormat("[Pilot '{3}'] Call OnChangeSolarSystem with key after publish {0} from {1} to {2} ", Name, LocationPreviousSystemName, LocationCurrentSystemName, Name);

            try
            {
                if (Global.ApplicationSettings.IsUseMap)
                    SpaceMap.SelectedSolarSystemName = LocationCurrentSystemName;

                if (OnChangeSolarSystem != null) OnChangeSolarSystem(this, LocationPreviousSystemName, LocationCurrentSystemName);
                if(OnEnterToSolarSystem != null)  OnEnterToSolarSystem(Name, LocationPreviousSystemName, LocationCurrentSystemName);
            }
            catch (Exception exception)
            {
                Log.ErrorFormat("[PilotEntity.ChangeLocation] Critical error = {0}", exception);
            }
        }
    }
}
