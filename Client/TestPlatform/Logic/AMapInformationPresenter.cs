
namespace EveJimaCore.Logic
{
    public class AMapInformationPresenter: IPresenter
    {
        IAMapInformationModel Model { get; }
        IAMapInformationView View { get; }

        public AMapInformationPresenter(IAMapInformationModel model, IAMapInformationView view)
        {
            Model = model;
            View = view;
        }

        public void Run()
        {
            View.Show();
        }
    }
}
