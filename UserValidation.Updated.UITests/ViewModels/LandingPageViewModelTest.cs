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
using UserValidation.Updated.ViewModels.UserDetailsViewModel;
using UserValidation.Updated.Gateway.Interace;

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
        public INavigationn _service { get; set; }

        #endregion

        #region INITIALIZATION

        [Test,Order(1)]
        public void Initialize()
        {
            _service = A.Fake<INavigationn>();         
            ViewModel = new LandingPageViewModel(_service);
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
        public async Task MoveToDetailsScreenAsync()
        {
            var response = new DetailsResponseGenerator().ForName().ForHeight().ForWeight().ForHairColour().ForSkinColour().ForEyeColour().ForBirthYear().ForGender().ForProfileCreationDate().Build();
            DataModel = new UserDataModel();
            DataModel.UserDetails = response;             
             
            ViewModel.SubmitCommand.Execute(null);

            //A.CallTo(() => _service.PushAsync(new UserDetailsPageViewModel(DataModel))).MustHaveHappened();
        }

        #endregion

        #region FIELDS

        private IHttpHandler fakehandler { get; set; }
        private UserDataModel DataModel;

        #endregion
    }
}
