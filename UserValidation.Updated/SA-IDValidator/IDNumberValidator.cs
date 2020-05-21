using System;

namespace UserValidation.Updated.SAIDValidator
{
    public static class IDNumberValidator
    {
        public static bool ValidateId(string number)
        {
            bool flag = false;

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

                if(CheckSum == lastdigit)
                {
                    var DobDigits = number.Substring(0, 6);
                    flag = InputStringValidator.ValidateDateOfBirth(DobDigits);
                    return flag;
                }
                
                return flag;                
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
