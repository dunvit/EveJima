
using EveJimaCore.BLL;

namespace EveJimaCore
{
    public delegate void EventOnChangeSelectedTab(string tabName);
    public delegate void DelegateChangeSolarSystemInfo(string info);
    public delegate void DelegateShowTravelHistory();
    public delegate void DelegateChangeSelectedPilot();
    public delegate void DelegateShowLocation();
    public delegate void DelegateShowLostAndFoundOffice();
    public delegate void DelegateShowSolarSystem();
    public delegate void OpenWebBrowser();

    public delegate void BrowserNavigate(string address);

    public delegate void DelegateContainerActivate(string name);

    
    
}
