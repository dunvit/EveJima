using System;
using System.Collections.Generic;

namespace EveJimaCore.Logic
{
    public interface IAMapInformationView: IView
    {
        void ShowInformationPanel(string panelName);

        //void ChangeSolarSystem(string solarSystem);

        //event Action<string> DeleteSelectedSystem;

        //event Action<string> CentreScreenSelectedSystem;

        //event Action<string> CentreScreenLocationSystem;

        //event Action<string, List<CosmicSignature>> UpdateSignatures;

        //event Action<string> ChangeMapKey;
    }
}
