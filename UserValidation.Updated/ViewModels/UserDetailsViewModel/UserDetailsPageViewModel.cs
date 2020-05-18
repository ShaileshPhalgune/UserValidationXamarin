using System;
using System.Globalization;
using UserValidation.Updated.Models;
using UserValidation.Updated.ViewModels.BaseViewModel;

namespace UserValidation.Updated.ViewModels.UserDetailsViewModel
{
    public class UserDetailsPageViewModel : ViewModelBase
    {
        #region PROPERTIES

        public string Name { get; set; }
        public string Height { get; set; }
        public string Weight { get; set; }
        public string HairColour { get; set; }
        public string SkinColour { get; set; }
        public string EyeColour { get; set; }
        public string BirthYear { get; set; }
        public string Gender { get; set; }
        public string ProfileCreationDate { get; set; }

        public UserDataModel DataModel { get; set; }

        #endregion

        #region CONSTRUCTION

        public UserDetailsPageViewModel(UserDataModel Model)
        {
            DataModel = Model;

            Name = DataModel.UserDetails.Name;
            Height = string.Format("{0} Cms", DataModel.UserDetails.Height);
            Weight = string.Format("{0} Kg", DataModel.UserDetails.Weight);

            HairColour = DataModel.UserDetails.HairColour;
            SkinColour = DataModel.UserDetails.SkinColour;
            EyeColour = DataModel.UserDetails.EyeColour;

            BirthYear = DataModel.UserDetails.BirthYear;
            Gender = DataModel.UserDetails.Gender;
            //TODO:- Change the date format 
            var DateReadable = ConvertDateToReadableFormat(DataModel.UserDetails.ProfileCreatedDate);
            ProfileCreationDate = DateReadable;
        }

        #endregion

        #region METHODS

        private string ConvertDateToReadableFormat(string date)
        {
            DateTime result = DateTime.Parse(date, CultureInfo.InvariantCulture, DateTimeStyles.AssumeLocal);
            return result.ToString();
        }

        #endregion
    }
}
