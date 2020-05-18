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
            UserDetailsServiceFake = A.Fake<IGetUserDetails>();
            
            //A.CallTo(() => UserDetailsServiceFake.GetUserDetails(A<string>.Ignored)).MustHaveHappened();

            var fakeShop = A.Fake<ServiceGetUserDetails>(options => options.Implements<IGetUserDetails>());
            A.CallTo(() => ((IGetUserDetails)fakeShop).GetUserDetails(A<string>.Ignored)).MustHaveHappened();
        }

        #endregion

        #region FIELDS

        private ServiceGetUserDetails GetUserDetailsFake;
        private IGetUserDetails UserDetailsServiceFake;
        private UserDataModel DataModel;
        private UserDetails UserData;

        #endregion
    }
}
