using System;
using System.Threading.Tasks;
using UserValidatation.Updated.Models;
using UserValidatation.Updated.Services.InterFace;

namespace UserValidation.Updated.Models
{
    public class UserDataModel
    {
        #region PROPERTIES

        public UserDetails UserDetails;

        #endregion

        #region CONSTRUCTION

        public UserDataModel(IGetUserDetails Service)
        {
            _service = Service;
        }

        #endregion

        #region METHODS

        public async Task<bool> GetUserInfoWithIdAsync(String UserId)
        {
            var Id = UserId;
            var response = await _service.GetUserDetails(Id);

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

        private IGetUserDetails _service { get; set; }

        #endregion
    }
}
