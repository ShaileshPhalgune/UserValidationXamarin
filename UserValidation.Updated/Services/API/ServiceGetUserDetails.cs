using System;
using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using UserValidatation.Updated.Services.DTO;
using UserValidatation.Updated.Services.InterFace;
using UserValidatation.Updated.Constant;

namespace UserValidatation.Updated.Services.API
{
    public class ServiceGetUserDetails:IGetUserDetails
    {
        #region CONSTRUCTION

        public ServiceGetUserDetails()
        {
            client = new HttpClient();
        }

        #endregion

        #region METHODS

        public async Task<UserDataResponse> GetUserDetails(string UserId)
        {
            UserInfo = new UserDataResponse();
            var GatewayURL = new Uri(string.Format(Constants.URL + UserId, string.Empty));
            try
            {
                var response = await client.GetAsync(GatewayURL);
                if (response.IsSuccessStatusCode)
                {
                    var contents = await response.Content.ReadAsStringAsync();
                    UserInfo = JsonConvert.DeserializeObject<UserDataResponse>(contents);
                    return UserInfo;
                }
                
            }
            catch (Exception exception)
            {
                Debug.WriteLine("ERROR IN LOADING {0}",exception.Message);
            }

            return null;
        }

        #endregion

        #region FIELDS

        private HttpClient client;
        private UserDataResponse UserInfo;

        #endregion
    }
}

