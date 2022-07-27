namespace CovidWebApp.Data
{
    public class Converter
    {
        // Klasa sluzaca do eleganckiego sformatowania reprezentacji liczb (np. 1234567 -> 1 234 567)
        public static string FromIntToString(int num)
        {
            string numStr = num.ToString();
            string reversStr = "";
            if (numStr.Length < 4)
            {
                return numStr;
            }
            else
            {
                int counter = 3;
                for (int i = numStr.Length - 1; i >= 0; i--)
                {
                    if (counter == 0)
                    {
                        reversStr += ' ';
                        reversStr += numStr[i];
                        counter = 2;
                    }
                    else
                    {
                        reversStr += numStr[i];
                        counter--;
                    }
                }
            }

            string resultString = "";
            for (int i = reversStr.Length - 1; i >= 0; i--)
            {
                resultString += reversStr[i];
            }

            return resultString;
        }
    }
}
