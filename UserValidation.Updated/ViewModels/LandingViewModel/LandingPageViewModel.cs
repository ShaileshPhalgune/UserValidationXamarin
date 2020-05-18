using System.Windows.Input;
using UserValidatation.Updated.Gateway.API;
using UserValidatation.Updated.Gateway.Service;
using UserValidation.Updated.Models;
using UserValidation.Updated.ViewModels.BaseViewModel;
using UserValidation.Updated.ViewModels.UserDetailsViewModel;
using Xamarin.Forms;

namespace UserValidation.Updated.ViewModels.LandingViewModel
{
    public class LandingPageViewModel:ViewModelBase
    {        
        #region PROPERTIES

        public string IDNumber
        {
            get { return _IdNumber; }
            set
            {
                _IdNumber = value;
                OnPropertyChanged();
            }
        }

        private bool isBusy;
        public bool IsBusy
        {
            get => isBusy;
            set
            {
                isBusy = value;
                OnPropertyChanged();
            }
        }

        public ICommand SubmitCommand { get; }

        #endregion

        #region CONSTRUCTION

        public LandingPageViewModel()
        {
            //_navigationService = NavigatonService;
            SubmitCommand = new Command(SubmitButtonClicked);
            DataModel = new UserDataModel(new  UserDetails());
        }

        #endregion

        #region METHODS

        private async void SubmitButtonClicked()
        {
            if (!string.IsNullOrEmpty(IDNumber))
            {
                IsBusy = true;

                var result = await DataModel.GetUserInfoWithIdAsync(IDNumber);

                IsBusy = false;

                if (result)
                {
                    await NavigationService.PushAsync(new UserDetailsPageViewModel(DataModel));
                }
                else
                {
                    await DependencyService.Get<AlertService>().ShowErrorAsync("User Not Found.", "Information", "OK");
                }
            }
        }

        #endregion

        #region FIELDS

        private string _IdNumber;
        private UserDataModel DataModel;

        #endregion
    }
}
