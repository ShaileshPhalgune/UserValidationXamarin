using System.Threading.Tasks;
using System.Windows.Input;
using UserValidatation.Updated.Gateway.API;
using UserValidatation.Updated.Gateway.Service;
using UserValidation.Updated.Gateway.Interace;
using UserValidation.Updated.Models;
using UserValidation.Updated.SAIDValidator;
using UserValidation.Updated.ViewModels.BaseViewModel;
using UserValidation.Updated.ViewModels.UserDetailsViewModel;
using Xamarin.Forms;

namespace UserValidation.Updated.ViewModels.LandingViewModel
{
    public class LandingPageViewModel:ViewModelBase
    {
        #region PROPERTIES

        public UserDataModel DataModel;
        public INavigationn _service { get; set; }

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
        public ICommand IdValidationCommand { get; }

        #endregion

        #region CONSTRUCTION

        public LandingPageViewModel(INavigationn NavigationService)
        {
            _service = NavigationService;

            SubmitCommand = new Command(SubmitButtonClicked);
            IdValidationCommand = new Command(ValidateIdNumber);
            DataModel = new UserDataModel();
        }

        #endregion

        #region METHODS

        public async void SubmitButtonClicked()
        {
            if (!string.IsNullOrEmpty(IDNumber))
            {
                IsBusy = true;

                var result = await DataModel.GetUserInfoWithIdAsync(IDNumber);

                IsBusy = false;

                if (result)
                {
                    await _service.PushAsync(new UserDetailsPageViewModel(DataModel));                    
                }
                else
                {
                    await DependencyService.Get<AlertService>().ShowErrorAsync("User Not Found.", "Information", "OK");
                }
            }
        }

        public async void ValidateIdNumber()
        {
            if(IDNumberValidator.ValidateId(IDNumber))
            {
                await DependencyService.Get<AlertService>().ShowErrorAsync("This is a valid south african ID Number", "Information", "OK");
            }
            else
            {
                await DependencyService.Get<AlertService>().ShowErrorAsync("This is not a south african ID Number", "Information", "OK");
            }
        }

        #endregion

        #region FIELDS

        private string _IdNumber;
        
        #endregion
    }
}
