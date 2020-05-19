using System;
using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using UserValidatation.Updated.Gateway.DTO;
using UserValidatation.Updated.Gateway.Interface;
using UserValidatation.Updated.Constant;
using UserValidation.Updated.Gateway.API;

namespace UserValidatation.Updated.Gateway.API
{
    public class GetUserDetails
    {
        #region CONSTRUCTION

        public GetUserDetails()
        {
            handler = new HttpRequestHandler();
        }

        #endregion

        #region METHODS

        public async Task<UserDataResponse> GetUserDetailsForId(string UserId)
        {
            var GatewayURL = string.Format(Constants.URL + UserId, string.Empty);
            try
            {
                var response = await handler.GetAsync(GatewayURL);
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

        private HttpRequestHandler handler;
        private UserDataResponse UserInfo;

        #endregion
    }
}

