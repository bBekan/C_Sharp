using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace ApiUsage
{
    internal class ApiHelper
    {
        public static HttpClient ApiClient { get; set; }

        public static void InitializeClient()
        {
            ApiClient = new HttpClient();
            ApiClient.DefaultRequestHeaders.Accept.Clear();
            ApiClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public static async Task<Character> GetCharacter(string id = "1")
        {
            if (string.IsNullOrEmpty(id)) id = "1";
            string url = $"https://swapi.dev/api/people/{id}/";
            return (Character)await ConnectToApi<Character>(url, ModelEnumerator.Character);
        }

        public static async Task<Planet> GetPlanet(string id = "1")
        {
            if (string.IsNullOrEmpty(id)) id = "1";
            string url = $"https://swapi.dev/api/planets/{id}/";
            return (Planet)await ConnectToApi<Planet>(url, ModelEnumerator.Planet);
        }

        public static async Task<Starship> GetStarship(string id)
        {
            if (string.IsNullOrEmpty(id)) id = "9";
            string url = $"https://swapi.dev/api/starships/{id}/";
            return (Starship)await ConnectToApi<Starship>(url, ModelEnumerator.Starship);
        }

        private static async Task<Object> ConnectToApi<T>(string url, ModelEnumerator model)
        {
            using (HttpResponseMessage response = await ApiClient.GetAsync(url))
            {
                if (response.IsSuccessStatusCode)
                {
                    switch (model)
                    {
                        case ModelEnumerator.Character:
                            Character character = await response.Content.ReadAsAsync<Character>();
                            return character;
                        case ModelEnumerator.Planet:
                            Planet planet = await response.Content.ReadAsAsync<Planet>();
                            return planet;
                        case ModelEnumerator.Starship:
                            Starship starship = await response.Content.ReadAsAsync<Starship>();
                            return starship;
                        default:
                            throw new Exception(response.ReasonPhrase);
                    }
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }

    }
}
 