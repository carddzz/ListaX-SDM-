using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace ConsumerAdviceApi
{
    class Program
    {
        static async Task Main(string[] args)
        {
            try
            {
                using HttpClient client = new HttpClient();
                string jsonResponse = await client.GetStringAsync("https://api.adviceslip.com/advice");

               
                var adviceData = JsonDocument.Parse(jsonResponse);
                string advice = adviceData.RootElement.GetProperty("slip").GetProperty("advice").GetString() ?? "Conselho indisponível";

                
                Console.WriteLine("Conselho de Hoje:");
                Console.WriteLine(advice);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ocorreu um erro: " + ex.Message);
            }
        }
    }
}
