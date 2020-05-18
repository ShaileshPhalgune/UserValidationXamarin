using System;
using System.Threading.Tasks;
using UserValidatation.Updated.Gateway.DTO;

namespace UserValidatation.Updated.Gateway.Interface
{
    public interface IUserDetails
    {
        Task<UserDataResponse>GetUserDetails(string UserId);
    }
}
