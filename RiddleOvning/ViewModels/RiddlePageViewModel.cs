using RiddleOvning.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace RiddleOvning.ViewModels
{
    internal class RiddlePageViewModel
    {


        public List<Riddle> TheRiddle { get; set; }

        public RiddlePageViewModel()
        {
            var task = Task.Run(() => GetUserAsync("v1/riddles?limit=3"));
            task.Wait();
            TheRiddle = task.Result;

        }

        public static async Task<List<Riddle>> GetUserAsync(string uri)
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri("https://api.api-ninjas.com/");
            client.DefaultRequestHeaders.Add("X-Api-Key", "zpHSqA1y7GNkkV4Sz1spRA==ES9TThFsQLVNjU3m");

            List<Models.Riddle> riddles = null;

            HttpResponseMessage response = await client.GetAsync(uri);
            if (response.IsSuccessStatusCode)
            {
                string responseString = await response.Content.ReadAsStringAsync();
                riddles = JsonSerializer.Deserialize<List<Models.Riddle>>(responseString);
              
            }
            return riddles;




        }
    }
}
