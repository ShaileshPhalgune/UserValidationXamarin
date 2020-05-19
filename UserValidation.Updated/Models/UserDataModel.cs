using System;
using System.Threading.Tasks;
using UserValidatation.Updated.Models;
using UserValidatation.Updated.Gateway.Interface;
using Xamarin.Forms;
using UserValidatation.Updated.Gateway.API;

namespace UserValidation.Updated.Models
{
    public class UserDataModel
    {
        #region PROPERTIES

        public UserDetails UserDetails;

        #endregion

        #region CONSTRUCTION

        public UserDataModel()
        {
            _service = new GetUserDetails();
        }

        #endregion

        #region METHODS

        public async Task<bool> GetUserInfoWithIdAsync(string UserId)
        {
            var Id = UserId;

            var response = await _service.GetUserDetailsForId(Id);

            if (response != null)
            {
                var UserInfo = new UserDetails();
                UserInfo.CreateDataModelFromResponse(response);

                UserDetails = UserInfo;

                return true;
            }
            else
            {
                return false;
            }
        }

        #endregion

        #region FIELDS

        private GetUserDetails _service { get; set; }

        #endregion
    }
}
