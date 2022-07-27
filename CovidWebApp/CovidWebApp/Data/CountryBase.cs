using CovidWebApp.Models;

namespace CovidWebApp.Data
{
    public class CountryBase
    {
        CountryModel? countryModel;

        public CountryBase(){}
        
        // Metoda readData() pobiera dane z API w formacie JSON i tworzy instancję modelu CountryModel
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

        // Metoda GetCountryModel() zwraca model CountryModel, o ile nie jest nullem
        public CountryModel GetCountryModel()
        {
            if (countryModel == null)
                throw new Exception("CountryModel is null.");
            
            return countryModel;
        }
    }
}
