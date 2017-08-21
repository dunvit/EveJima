using System;
using System.Collections.Generic;
using System.Drawing;
using EvaJimaCore;
using EveJimaCore.BLL.Map;
using EveJimaCore.WhlControls;
using EveJimaUniverse;
using log4net;

namespace EveJimaCore.Logic.MapInformation
{
    public partial class MapControl : BaseContainer, IAMapInformationView
    {
        readonly ILog _errorsLog = LogManager.GetLogger("Errors");
        readonly ILog _commandsLog = LogManager.GetLogger("CommandsMap");
        private static readonly ILog Log = LogManager.GetLogger(typeof(MapControl));

        public MapControl()
        {
            InitializeComponent();
            Log.DebugFormat("[MapControl.MapControl] start");
            containerInformation.CentreScreenLocationSystem += Event_CentreScreenLocationSystem;
            containerInformation.CentreScreenSelectedSystem += Event_CentreScreenSelectedSystem;
            containerInformation.DeleteSelectedSystem += Event_DeleteSelectedSystem;
            containerInformation.UpdateSignatures += Event_UpdateSignatures;
            containerInformation.DeathNotice += Event_DeathNotice;
            containerToolbar.OnSelectTab += Event_SelectTab;
            containerInformation.ChangeMapKey += Event_ChangeMapKey;
            containerInformation.ReloadMap += Event_ReloadMap;
            containerMap.SelectSolarSystem += Event_SelectSolarSystem;
            containerMap.RelocateSolarSystem += Event_RelocateSolarSystem;
            containerMap.DeleteWormhole += EventDeleteWormhole;
            containerMap.ReloadMap += Event_ReloadMap;
            Global.Presenter.OnLocationChange += Event_LocationChanged;
            Global.Presenter.OnChangeScreen += Event_ChangeScren;
            Global.Presenter.OnChangeActivePilot += Event_ActivePilotChanged;
        }

        private void EventDeleteWormhole(string solarSystemFrom, string solarSystemTo)
        {
            containerMap.StopDrawMap();

            _commandsLog.InfoFormat($"[MapControl.Event_DeleteSolarSystemConnection]  Delete connection between {solarSystemFrom} and {solarSystemTo} solar systems.");

            Global.Pilots.Selected.SpaceMap.ApiDeleteConnectionBeetwenSolarSystems( solarSystemFrom, solarSystemTo);

            containerMap.ForceRefresh(Global.Pilots.Selected.SpaceMap);
            

            containerMap.StartDrawMap();
        }

        private void Event_ChangeScren(string screenName)
        {
            if(screenName == "Map")
            {
                containerMap.StartDrawMap();
            }
            else
            {
                containerMap.StopDrawMap();
            }
        }

        private void Event_ReloadMap(string key)
        {
            containerMap.StopDrawMap();

            var screen = new ScreenUpdateToServer { ActionType = "ReloadMap", MapKey = key };
            screen.RefreshMapControl += Event_RefreshMap;
            screen.ShowDialog();

            _commandsLog.InfoFormat("[ScreenUpdateToServer.Event_Activate] " + "After change mapKey");

            containerMap.StartDrawMap();
        }

        private void Event_ChangeMapKey(string key)
        {
            containerMap.StopDrawMap();

            var screen = new ScreenUpdateToServer { ActionType  = "ChangeMapKey", MapKey = key};
            screen.RefreshMapControl += Event_RefreshMap;
            screen.ShowDialog();

            _commandsLog.InfoFormat("[ScreenUpdateToServer.Event_Activate] " + "After change mapKey");

            containerMap.ForceRefresh(Global.Pilots.Selected.SpaceMap);
            containerInformation.ForceRefresh(Global.Pilots.Selected.SpaceMap);

            containerMap.StartDrawMap();
        }

        private void Event_RefreshMap(string obj)
        {
            Log.DebugFormat("[MapControl.Event_RefreshMap] start");
            containerMap.ForceRefresh(Global.Pilots.Selected.SpaceMap);
            containerInformation.ForceRefresh(Global.Pilots.Selected.SpaceMap);
        }

        private void Event_UpdateSignatures(string arg1, List<CosmicSignature> signatures)
        {
            Global.Pilots.Selected.SpaceMap.ApiPublishSignatures(
                Global.Pilots.Selected.SpaceMap.Key, 
                Global.Pilots.Selected.SpaceMap.LocationSolarSystemName,
                Global.Pilots.Selected.Name,signatures);
        }

        private void Event_DeathNotice(string selectedSolarSystemName)
        {
            Global.MapApiFunctions.PublishDeadLetter(Global.Pilots.Selected.SpaceMap, Global.Pilots.Selected.SpaceMap.Key, Global.Pilots.Selected.Name, Global.Pilots.Selected.LocationPreviousSystemName, selectedSolarSystemName);

            containerMap.ForceRefresh(Global.Pilots.Selected.SpaceMap);
        }

        private void Event_DeleteSelectedSystem(string selectedSolarSystemName)
        {
            var screen = new ScreenUpdateToServer { ActionType = "DeleteSystem", MapKey = Global.Pilots.Selected.SpaceMap.Key };
            screen.RefreshMapControl += Event_RefreshMap;
            screen.ShowDialog();

            _commandsLog.InfoFormat("[ScreenUpdateToServer.Event_Activate] " + "After change mapKey");

            containerMap.ForceRefresh(Global.Pilots.Selected.SpaceMap);
            containerInformation.ForceRefresh(Global.Pilots.Selected.SpaceMap);
        }

        private void Event_CentreScreenSelectedSystem(string obj)
        {
            containerMap.CentreScreenBySelectedSystem();
        }

        private void Event_CentreScreenLocationSystem(string obj)
        {
            containerMap.CentreScreenByLocationSystem();
        }

        private void Event_RelocateSolarSystem(Point solarSystemNewLocationInMap, string arg2)
        {
            try
            {
                Global.MapApiFunctions.UpdateSolarSystemCoordinates(Global.Pilots.Selected.SpaceMap, Global.Pilots.Selected.SpaceMap.Key, Global.Pilots.Selected.SpaceMap.SelectedSolarSystemName, Global.Pilots.Selected.SpaceMap.ActivePilot, solarSystemNewLocationInMap.X, solarSystemNewLocationInMap.Y, Global.Pilots.Selected.SpaceMap.GetLastUpdate());
            }
            catch (Exception ex)
            {
                _errorsLog.ErrorFormat("[MapModel.RelocateSolarSystem] Point = {1} SolarSystemName = {2} Critical error {0}", ex, solarSystemNewLocationInMap, Global.Pilots.Selected.SpaceMap.SelectedSolarSystemName);
            }
        }

        private void Event_SelectSolarSystem(string obj)
        {
            containerInformation.ChangeLocation(Global.Pilots.Selected.SpaceMap);
        }

        private void Event_ActivePilotChanged(Map spaceMap)
        {
            Log.DebugFormat("[MapControl.Event_ActivePilotChanged] start");
            containerMap.ForceRefresh(spaceMap);
            containerInformation.ForceRefresh(spaceMap);
        }

        private void Event_LocationChanged(Map spaceMap)
        {
            Log.DebugFormat("[MapControl.Event_LocationChanged] start");
            containerInformation.ChangeLocation(spaceMap);
            Log.DebugFormat("[MapControl.Event_LocationChanged] end");
        }

        private void Event_SelectTab(string containerName)
        {
            containerInformation.ActivatePanel(containerName);
        }

        private void MapControl_Load(object sender, EventArgs e)
        {

        }

        public void Close()
        {
        }

        public void Event_Map_OnResize()
        {
        }


    }
}
