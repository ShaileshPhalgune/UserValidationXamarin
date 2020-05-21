using System;
using UserValidation.Updated.ViewModels.BaseViewModel;
using UserValidation.Updated.ViewModels.LandingViewModel;

namespace UserValidation.Updated.SAIDValidator
{
    public static class IDNumberValidator
    {
        public static bool ValidateId(string number, LandingPageViewModel ViewModel)
        {
            bool flag = false;
            LandingPageViewModel _viewmodel = ViewModel;

            number = InputStringValidator.RemovingWhiteSpaces(number);

            if (number.Length == 13 && !InputStringValidator.HasSpecialCharacter(number))
            {
                var digitArray = number.ToCharArray();
                var OddSum = 0;
                var lastdigit = 0;
                string EvenDigits = string.Empty;
                int i = 1;

                while(i <= digitArray.Length)
                {
                    var digit = (int)Char.GetNumericValue(digitArray[i-1]);
                    
                    if (i == digitArray.Length)
                    {
                        lastdigit = digit;
                    }
                    else
                    {                       
                        if (i % 2 != 0)
                        {
                            OddSum += digit;
                        }
                        else
                        {
                            EvenDigits += (digit.ToString());                            
                        }                        
                    }

                    i++;
                }

                int EvenSum = GetEvenSum(EvenDigits);
                var CheckSum = 10 - ((OddSum + EvenSum) % 10);
                var DobDigits = number.Substring(0, 6);

                var IDValid = CheckSum == lastdigit;
                var DateValid = InputStringValidator.ValidateDateOfBirth(DobDigits);

                if (IDValid && DateValid)
                {
                    flag = true;

                    _viewmodel.IsIDValid = true;
                    _viewmodel.IDDescription = string.Format( "ID Status : Valid ID Number");

                    _viewmodel.IsDOBValid = true;
                    _viewmodel.DateOfBirth = string.Format("Date Of Birth : {0}", IDParameterParser.GenerateDate(DobDigits));

                    _viewmodel.IsGenderValid = true;
                    var Gender = IDParameterParser.GetGender(digitArray[6]);
                    _viewmodel.Gender = string.Format("Gender : {0}", Gender);

                    _viewmodel.IsValidSACitizen = true;
                    var Citizen = IDParameterParser.GetCitizenShipStatus(digitArray[10]);
                    _viewmodel.SACitizen = string.Format("Citizenship Status : {0}", Citizen);

                    return flag;
                }
                else
                {
                    return flag;
                }                
            }

            return flag;
        }

        private static int GetEvenSum(string number)
        {
            var DigitsInInt = int.Parse(number) * 2;
            return AddDigits(DigitsInInt);
        }

        private static int AddDigits(int number)
        {
            var sum = 0;

            while (number != 0)
            {
                sum += number % 10;
                number /= 10;
            }

            return sum;
        }       
    }    
}
