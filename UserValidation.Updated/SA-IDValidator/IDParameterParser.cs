using System;
using System.Globalization;

namespace UserValidation.Updated.SAIDValidator
{
    public static class IDParameterParser
    {
        public static string GenerateDate(string DateInString)
        {
            DateTime OutPut;
            DateTime.TryParseExact(DateInString, "yymmdd", CultureInfo.InvariantCulture, DateTimeStyles.None, out OutPut);
            return OutPut.ToString("dd-mm-yyyy");
        }

        public static string GetGender(char GenderValue)
        {
            var value = (int)Char.GetNumericValue(GenderValue);
            return value < 5 ? "Female" : "Male";
        }

        public static string GetCitizenShipStatus(char GenderValue)
        {
            var value = (int)Char.GetNumericValue(GenderValue);
            var Status = "Not a SA Citizen";
            if (value == 0)
            {
                Status = "South African Citizen";
            }
            else if (value == 1)
            {
                Status = "Permanent Resident";
            }
            return Status;
        }
    }
}
