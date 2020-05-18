using System;
using System.Net.Http;

namespace UserValidatation.Updated.Services.DTO
{
    public class UserDataResponse
    {
        #region PROPERTIES

        public string name { get; set; }
        public string height { get; set; }
        public string mass { get; set; }
        public string hair_color { get; set; }
        public string skin_color { get; set; }
        public string eye_color { get; set; }
        public string birth_year { get; set; }
        public string gender { get; set; }
        public string created { get; set; }

        #endregion
    }
}
