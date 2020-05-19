using System;
using UserValidatation.Updated.Gateway.DTO;
using UserValidatation.Updated.Models;

namespace UserValidation.Updated.ResponseGenerators.UserDetailsResponseGenerator
{
    public class DetailsResponseGenerator
    {
        #region METHODs

        public UserDetails Build()
        {
            return new UserDetails
            {
                Name = _name,
                Height = _height,
                Weight = _weight,
                HairColour = _haircolour,
                SkinColour = _skincolour,
                EyeColour = _eyecolour,
                BirthYear = _birthyear,
                Gender = _gender,
                ProfileCreatedDate = _profilecreationdate              
            };
        }

        public DetailsResponseGenerator ForName()
        {
            _name = "Shailesh Phalgune";
            return this;
        }

        public DetailsResponseGenerator ForHeight()
        {
            _height = "175 Cms";
            return this;
        }

        public DetailsResponseGenerator ForWeight()
        {
            _weight = "80 Kg";
            return this;
        }

        public DetailsResponseGenerator ForHairColour()
        {
            _haircolour = "Brown";
            return this;
        }

        public DetailsResponseGenerator ForSkinColour()
        {
            _skincolour = "Fair";
            return this;
        }

        public DetailsResponseGenerator ForEyeColour()
        {
            _eyecolour = "Black";
            return this;
        }

        public DetailsResponseGenerator ForBirthYear()
        {
            _birthyear = "19BBY";
            return this;
        }

        public DetailsResponseGenerator ForGender()
        {
            _gender = "Male";
            return this;
        }

        public DetailsResponseGenerator ForProfileCreationDate()
        {
            _profilecreationdate = "12/09/2014 7:20:51 PM";
            return this;
        }

        #endregion

        #region FIELDS

        private string _name;
        private string _height;
        private string _weight;
        private string _haircolour;
        private string _skincolour;
        private string _eyecolour;
        private string _birthyear;
        private string _gender;
        private string _profilecreationdate;

        #endregion
    }
}
