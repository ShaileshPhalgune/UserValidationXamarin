using System;
using System.Threading.Tasks;
using UserValidatation.Updated.IOC;
using UserValidation.Updated.ViewModels.BaseViewModel;
using Xamarin.Forms;

namespace UserValidatation.Updated.Gateway.Service
{
    #region METHODS

    public static class NavigationService
	{
		public static async Task PushAsync (ViewModelBase viewModel)
		{
			var view = SimpleIoC.GetPage (viewModel.GetType ());
			view.BindingContext = viewModel;
			await Navigation.PushAsync (view);
		}
        
		public static void SetInitialPage (object viewModel)
		{
			var view = SimpleIoC.GetPage (viewModel.GetType ()); 
			view.BindingContext = viewModel;
			Application.Current.MainPage = new NavigationPage(view);
		}

		static INavigation Navigation
		{
			get
			{							
				return Application.Current.MainPage.Navigation;
			}
		}

        #endregion
    }
}

