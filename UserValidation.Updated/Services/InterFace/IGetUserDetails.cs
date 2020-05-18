using System;
using System.Threading.Tasks;
using UserValidatation.Updated.Services.DTO;

namespace UserValidatation.Updated.Services.InterFace
{
    public interface IGetUserDetails
    {
        Task<UserDataResponse>GetUserDetails(string UserId);
    }
}
