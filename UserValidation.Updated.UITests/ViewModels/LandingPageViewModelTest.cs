using NUnit.Framework;
using UserValidation.Updated.ViewModels.LandingViewModel;
using UserValidation.Updated.Models;
using UserValidation.Updated.Gateway.Interface;
using FakeItEasy;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net;
using UserValidatation.Updated.Constant;
using UserValidation.Updated.ResponseGenerators.UserDetailsResponseGenerator;
using UserValidatation.Updated.Gateway.Service;
using UserValidation.Updated.ViewModels.UserDetailsViewModel;
using Xamarin.Forms;

namespace UserValidation.Updated.UITests.ViewModels
{
    [TestFixture]
    public class LandingPageViewModelTest
    {
        #region CONSTANTS

        private string MockResponeString = "{\"name\":\"Luke Skywalker\",\"height\":\"172\",\"mass\":\"77\",\"hair_color\":\"blond\",\"skin_color\":\"fair\",\"eye_color\":\"blue\",\"birth_year\":\"19BBY\",\"gender\":\"male\",\"homeworld\":\"http://swapi.dev/api/planets/1/\",\"films\":[\"http://swapi.dev/api/films/1/\",\"http://swapi.dev/api/fi…";

        #endregion

        #region PROPERTIES

        public LandingPageViewModel ViewModel { get; set; }

        #endregion

        #region INITIALIZATION

        [Test,Order(1)]
        public void Initialize()
        {
            ViewModel = new LandingPageViewModel();
            DataModel = new UserDataModel();
        }

        #endregion
        
        #region TEST METHODS

        [Test,Order(2)]
        public async Task GetUserDetailsTest()
        {         
            fakehandler = A.Fake<IHttpHandler>();
            DataModel = new UserDataModel();

            A.CallTo(() => fakehandler.GetAsync(A<string>.Ignored)).Returns(Task.FromResult(new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(MockResponeString)
            }));

            ViewModel.IDNumber = "1";
            var response = await fakehandler.GetAsync(Constants.URL+ViewModel.IDNumber);
            var responseBody = await response.Content.ReadAsStringAsync();

            Assert.AreEqual(HttpStatusCode.OK,response.StatusCode);
            Assert.AreEqual(MockResponeString, responseBody);           
        }

        [Test,Order(3)]
        public void MoveToDetailsScreen()
        {
                       
        }

        #endregion

        #region FIELDS

        private IHttpHandler fakehandler { get; set; }
        private UserDataModel DataModel;

        #endregion
    }
}
