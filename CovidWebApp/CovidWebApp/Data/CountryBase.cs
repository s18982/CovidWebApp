namespace CovidWebApp.Data
{
    public class CountryBase
    {
        static string result="";

        public CountryBase()
        {
            
        }
        
        public async Task readData(string url)
        {
            try
            {
                HttpClient client = new HttpClient();
                HttpResponseMessage response = await client.GetAsync(url);
                
                if (response.IsSuccessStatusCode)
                {
                    result = await response.Content.ReadAsStringAsync();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
        
        public string getResult()
        {
            return result;
        }
    }
}
