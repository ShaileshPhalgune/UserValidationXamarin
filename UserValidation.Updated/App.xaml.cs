using UserValidatation.Updated.IOC;
using UserValidatation.Updated.Gateway.Service;
using UserValidation.Updated.ViewModels.LandingViewModel;
using UserValidation.Updated.ViewModels.UserDetailsViewModel;
using UserValidation.Updated.Views.DetailsPage;
using UserValidation.Updated.Views.LandingPage;
using Xamarin.Forms;
using UserValidation.Updated.Gateway.Service;

namespace UserValidation.Updated
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            RegisterPages();
            //NavigationService.SetInitialPage(new LandingPageViewModel());
            SetInitialPage();
        }

        void RegisterPages()
        {
            SimpleIoC.RegisterPage<LandingPageViewModel, LandingPage>();
            SimpleIoC.RegisterPage<UserDetailsPageViewModel, UserDetailsPage>();
            DependencyService.Register<AlertService>();           
        }

        void SetInitialPage()
        {
            var service = new NavigateService();
            service.SetInitialPage(new LandingPageViewModel(service));
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
