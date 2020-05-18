using System;
using NUnit.Framework;
using Xamarin.UITest;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UserValidation.Updated.ViewModels.LandingViewModel;
using System.Threading.Tasks;
using UserValidatation.Updated.Services.InterFace;
using UserValidation.Updated.Models;
using FakeItEasy;
using Xamarin.Forms;
using UserValidatation.Updated.Models;
using UserValidatation.Updated.Services.API;

namespace UserValidation.Updated.UITests.ViewModels
{
    [TestClass]
    public class LandingPageViewModelTest
    {
        #region PROPERTIES

        public LandingPageViewModel ViewModel { get; set; }

        #endregion

        #region INITIALIZATION

        [TestInitialize]
        public void Initialize()
        {
            ViewModel = new LandingPageViewModel();
        }

        #endregion

        #region TEST METHODS

        [TestMethod]
        public void RunUserValidation()
        {
            UserDetailsServiceFake = A.Fake<IUserDetails>();
            
            //A.CallTo(() => UserDetailsServiceFake.GetUserDetails(A<string>.Ignored)).MustHaveHappened();

            var fakeShop = A.Fake<UserValidatation.Updated.Services.API.UserDetails>(options => options.Implements<IUserDetails>());
            A.CallTo(() => ((IUserDetails)fakeShop).GetUserDetails(A<string>.Ignored)).MustHaveHappened();
        }

        #endregion

        #region FIELDS

        private UserValidatation.Updated.Services.API.UserDetails GetUserDetailsFake;
        private IUserDetails UserDetailsServiceFake;
        private UserDataModel DataModel;
        private UserValidatation.Updated.Models.UserDetails UserData;

        #endregion
    }
}
