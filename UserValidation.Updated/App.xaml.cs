using UserValidatation.Updated.IOC;
using UserValidatation.Updated.Gateway.Service;
using UserValidation.Updated.ViewModels.LandingViewModel;
using UserValidation.Updated.ViewModels.UserDetailsViewModel;
using UserValidation.Updated.Views.DetailsPage;
using UserValidation.Updated.Views.LandingPage;
using Xamarin.Forms;

namespace UserValidation.Updated
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            RegisterPages();
            NavigationService.SetInitialPage(new LandingPageViewModel());            
        }

        void RegisterPages()
        {
            SimpleIoC.RegisterPage<LandingPageViewModel, LandingPage>();
            SimpleIoC.RegisterPage<UserDetailsPageViewModel, UserDetailsPage>();
            DependencyService.Register<AlertService>();           
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
