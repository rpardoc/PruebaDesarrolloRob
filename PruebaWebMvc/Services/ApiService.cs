using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace PruebaWebMvc.Services
{
    public class ApiService
    {

        private readonly string baseUrl =
            "https://localhost:44359/api/";


        private readonly HttpClient client;



        public ApiService()
        {
            client = new HttpClient();
        }




        public async Task<T> Get<T>(
            string endpoint)
        {
            try
            {

                HttpResponseMessage response =
                    await client.GetAsync(
                        baseUrl + endpoint);



                response.EnsureSuccessStatusCode();



                string json =
                    await response.Content
                    .ReadAsStringAsync();



                return JsonConvert
                    .DeserializeObject<T>(json);

            }
            catch (Exception ex)
            {
                throw new Exception(
                    "Error consumiendo API: "
                    + ex.ToString());
            }
        }





        public async Task<T> Post<T>(
            string endpoint,
            object data)
        {
            try
            {

                string json =
                    JsonConvert.SerializeObject(data);



                StringContent content =
                    new StringContent(
                        json,
                        Encoding.UTF8,
                        "application/json");



                HttpResponseMessage response =
                    await client.PostAsync(
                        baseUrl + endpoint,
                        content);



                // response.EnsureSuccessStatusCode();
                if (!response.IsSuccessStatusCode)
                {
                    string error =
                        await response.Content.ReadAsStringAsync();

                    throw new Exception(
                        $"API respondió {response.StatusCode}: {error}");
                }


                string resultado =
                    await response.Content
                    .ReadAsStringAsync();



                return JsonConvert
                    .DeserializeObject<T>(resultado);

            }
            catch (Exception ex)
            {
                throw new Exception(
                    "Error consumiendo API: "
                    + ex.ToString());
            }
        }

    }
}