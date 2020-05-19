using System;
using UserValidatation.Updated.Gateway.DTO;

namespace UserValidatation.Updated.Models
{
    public class UserDetails
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
        public string ProfileCreatedDate { get; set; }
        public bool Success { get; set; }

        #endregion

        #region METHODS

        public void CreateDataModelFromResponse(UserDataResponse response)
        {
            if (response != null)
            {
                Name = response.name;
                Height = response.height;
                Weight = response.mass;
                HairColour = response.hair_color;
                SkinColour = response.skin_color;
                EyeColour = response.eye_color;
                BirthYear = response.birth_year;
                Gender = response.gender;
                ProfileCreatedDate = response.created;
            }
        }

        #endregion
    }
}
