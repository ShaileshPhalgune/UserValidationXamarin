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

        public string IDDescription
        {
            get { return _IdAuthentic; }
            set
            {
                _IdAuthentic = value;
                OnPropertyChanged();
            }
        }

        public string DateOfBirth
        {
            get { return _DateOfBirth; }
            set
            {
                _DateOfBirth = value;
                OnPropertyChanged();
            }
        }

        public string Gender
        {
            get { return _Gender; }
            set
            {
                _Gender = value;
                OnPropertyChanged();
            }
        }

        public string SACitizen
        {
            get { return _SACitizen; }
            set
            {
                _SACitizen = value;
                OnPropertyChanged();
            }
        }

        public string IDNumber
        {
            get { return _IdNumber; }
            set
            {
                _IdNumber = value;
                OnPropertyChanged();
            }
        }
        
        public bool IsBusy
        {
            get => isBusy;
            set
            {
                isBusy = value;
                OnPropertyChanged();
            }
        }

        public bool IsIDValid
        {
            get => _isIdValid;
            set
            {
                _isIdValid = value;
                OnPropertyChanged();
            }
        }

        public bool IsDOBValid
        {
            get => isDOBValid;
            set
            {
                isDOBValid = value;
                OnPropertyChanged();
            }
        }

        public bool IsGenderValid
        {
            get => isGenderValid;
            set
            {
                isGenderValid = value;
                OnPropertyChanged();
            }
        }

        public bool IsValidSACitizen
        {
            get => isValidSACitizen;
            set
            {
                isValidSACitizen = value;
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
            

            if(!IDNumberValidator.ValidateId(IDNumber, this))
            {
                IsDOBValid = false;
                IsIDValid = false;
                isGenderValid = false;
                IsValidSACitizen = false;

                await DependencyService.Get<AlertService>().ShowErrorAsync("This is not a valid South African ID Number", "Information", "OK");
            }            
        }

        #endregion

        #region FIELDS

        private string _IdNumber;
        private string _IdAuthentic;
        private string _DateOfBirth;
        private string _Gender;
        private string _SACitizen;

        private bool isBusy;
        private bool _isIdValid;
        private bool isDOBValid;
        private bool isGenderValid;
        private bool isValidSACitizen;


        #endregion
    }
}
