using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using UserValidation.Updated.Models;
using UserValidation.Updated.ResponseGenerators.UserDetailsResponseGenerator;
using UserValidation.Updated.ViewModels.UserDetailsViewModel;
using Assert = NUnit.Framework.Assert;

namespace UserValidation.Updated.UITests.ViewModels
{
    [TestFixture]
    public class UserDetailsPageViewModelTests
    {
        #region PROPERTIES

        UserDetailsPageViewModel ViewModel { get; set; }

        #endregion

        #region INITIALIZATION

        [Test, Order(1)]
        public void CreateDisplayData()
        {
            var response = new DetailsResponseGenerator().ForName().ForHeight().ForWeight().ForHairColour().ForSkinColour().ForEyeColour().ForBirthYear().ForGender().ForProfileCreationDate().Build();
            DataModel = new UserDataModel();
            DataModel.UserDetails = response;
            ViewModel = new UserDetailsPageViewModel(DataModel);

            Assert.IsNotNull(DataModel.UserDetails);

            Assert.AreEqual("Shailesh Phalgune", DataModel.UserDetails.Name);
            Assert.AreEqual("175 Cms", DataModel.UserDetails.Height);
            Assert.AreEqual("80 Kg", DataModel.UserDetails.Weight);

            Assert.AreEqual("Brown", DataModel.UserDetails.HairColour);
            Assert.AreEqual("Fair", DataModel.UserDetails.SkinColour);
            Assert.AreEqual("Black", DataModel.UserDetails.EyeColour);

            Assert.AreEqual("19BBY", DataModel.UserDetails.BirthYear);
            Assert.AreEqual("Male", DataModel.UserDetails.Gender);
            Assert.AreEqual("12/09/2014 7:20:51 PM", DataModel.UserDetails.ProfileCreatedDate);
        }

        #endregion

        #region FIELDS

        private UserDataModel DataModel;

        #endregion
    }
}
