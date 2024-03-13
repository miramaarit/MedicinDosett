using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace MedicinDosett.ViewModels
{
    internal class ChatGPTManager
    {
        
        public string TheMedicin { get; set; }

        public ChatGPTManager(string medicinName)
        {


            var task = Task.Run(() => GetMedicin(medicinName));
            task.Wait();
            TheMedicin = task.Result;
            //ReadWriteFile.WriteFile("Medicin: " +TheMedicin); // för att skriva  i fil

        }

        public static async Task<string> GetMedicin(string medicinName)
        
        {
            try
            {

                string endpoint = "https://api.openai.com/v1/chat/completions";
                string key = "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";

                var data = new
                {
                    model = "gpt-3.5-turbo-1106",
                    messages = new[]
                    {
                    new
                    {
                        role="user",
                        content = "Kan du ge mig läkemedlsinformation på: " + medicinName
                    },

                },
                    temperature = 0.7
                };

                string requestString = JsonSerializer.Serialize(data);

                var content = new StringContent(requestString, Encoding.UTF8, "application/json");

                HttpClient client = new HttpClient();
                client.DefaultRequestHeaders.Add("Authorization", "Bearer " + key);

                var response = await client.PostAsync(endpoint, content);

                string responseJson = await response.Content.ReadAsStringAsync();

                var responseObject = JsonSerializer.Deserialize<Models.Response>(responseJson);

                return responseObject.choices[0].message.content;
            }
            catch (Exception ex)
            {
                
                throw new Exception("Ett fel uppstod vid hämtning av medicininformation!" + ex.Message);
            }
            
           
        }
    }
}
