using CovidWebApp.Models;

namespace CovidWebApp.Data
{
    public class CountryBase
    {
        CountryModel? countryModel;

        public CountryBase(){}
        
        public async Task readData(string url)
        {
            try
            {
                HttpClient client = new HttpClient();
                HttpResponseMessage response = await client.GetAsync(url);
#pragma warning disable CS8602 // Wyłuskanie odwołania, które może mieć wartość null.
                if (response.IsSuccessStatusCode && response.Content is object && response.Content.Headers.ContentType.MediaType == "application/json")
                {   
                    countryModel = await response.Content.ReadFromJsonAsync<CountryModel>();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        public CountryModel GetCountryModel()
        {
            if (countryModel == null)
                throw new Exception("CountryModel is null.");
            
            return countryModel;
        }
    }
}
