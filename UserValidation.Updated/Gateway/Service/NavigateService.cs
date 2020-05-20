using System;
using System.Threading.Tasks;
using UserValidatation.Updated.IOC;
using UserValidation.Updated.Gateway.Interace;
using UserValidation.Updated.ViewModels.BaseViewModel;
using Xamarin.Forms;

namespace UserValidation.Updated.Gateway.Service
{
    public class NavigateService : INavigationn
    {
        public NavigateService()
        {

        }

        public async Task PushAsync(ViewModelBase viewModel)
        {
            var view = SimpleIoC.GetPage(viewModel.GetType());
            view.BindingContext = viewModel;
            await Navigation.PushAsync(view);
        }

        public void SetInitialPage(object viewModel)
        {
            var view = SimpleIoC.GetPage(viewModel.GetType());
            view.BindingContext = viewModel;
            Application.Current.MainPage = new NavigationPage(view);
        }

        public INavigation Navigation
        {
            get
            {
                return Application.Current.MainPage.Navigation;
            }
        }
    }
}
