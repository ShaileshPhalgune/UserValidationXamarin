using System;
namespace UserValidation.Updated.SAIDValidator
{
    public static class InputStringValidator
    {
        public static string RemovingWhiteSpaces(string SourceString)
        {
            return SourceString.Replace(" ", string.Empty);
        }

        public static bool HasSpecialCharacter(string source)
        {
            foreach (var chars in source)
            {
                if (!char.IsLetterOrDigit(chars))
                {
                    return true;
                }
            }

            return false;
        }
    }
}
