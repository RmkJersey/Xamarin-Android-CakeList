namespace CakeList.Utility
{
    public class FormatString
    {
        /// <summary>Cleans up the input string removing leading and trailing edges, and upper cases first letter</summary>
        /// <param name="stringInput">string</param>
        /// <returns>Newly formatted <c>string</c></returns>
        public static string FirstCharToUpperTrimWhiteSpace(string stringInput)
        {
            return FirstCharToUpper(stringInput.Trim());
        }

        /// <summary>Upper case first letter of string</summary>
        /// <param name="stringInput">string</param>
        /// <returns>Upper cased first word of <c>string</c></returns>
        public static string FirstCharToUpper(string stringInput)
        {
            // Check for empty string
            if (string.IsNullOrEmpty(stringInput))
            {
                return string.Empty;
            }

            // Return 1st char uppercase and concat remainder substring
            return char.ToUpper(stringInput[0]) + stringInput.Substring(1);
        }
    }
}