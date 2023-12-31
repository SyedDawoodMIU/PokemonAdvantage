using PokemonAdvantage.Interfaces;

namespace PokemonAdvantage
{
    public class ApiService : IApiService
    {

        private readonly IErrorHandler _errorHandler;
        private readonly ISingletonHttpClient _singletonHttpClient;
        public ApiService(IErrorHandler errorHandler, ISingletonHttpClient singletonHttpClient)
        {
            _errorHandler = errorHandler;
            _singletonHttpClient = singletonHttpClient;

        }


        public async Task<string> Fetch(string url)
        {
            try
            {
                HttpResponseMessage response = await _singletonHttpClient.Instance.GetAsync(url);

                if (!response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    _errorHandler.HandleError(new Exception($"API call failed, the response from API was: {content}"));
                    return default!;
                }

                if (response.Content is null)
                {
                    _errorHandler.HandleError(new Exception("No content returned from API"));
                    return default!;
                }

                return await response.Content.ReadAsStringAsync();
            }
            catch (Exception ex)
            {
                _errorHandler.HandleError(new Exception("Error fetching data from API"));
                return default!;
            }
        }


    }
}
