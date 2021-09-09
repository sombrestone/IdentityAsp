using Microsoft.AspNetCore.SignalR.Client;
using System;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace dbLog
{
    class Program
    {
        static void Main(string[] args)
        {
            MainAsync().GetAwaiter().GetResult();
        }

        static async Task MainAsync()
        {
            var jwtToken = await GetAccessToken();
            
            var hubConnection = new HubConnectionBuilder()
            .WithUrl("https://localhost:44342/dblog",options=> {
                options.AccessTokenProvider = () => Task.FromResult(jwtToken);
            })
            .Build();

            hubConnection.On<string>("addMessage", param => {
                Console.WriteLine(param);
            });

            hubConnection.On<string, string>("ReceiveMessage",
                (string user, string message) =>
                    {
                        Console.WriteLine($"Message from {user}: {message}");
                });

            await hubConnection.StartAsync();
            await Task.Delay(-1);

        }

        class Tok
        {
            public Tok() { }
            public string token { get; set; }
        }


        static async Task<string> GetAccessToken()
        {
            string json = File.ReadAllText(Directory.GetCurrentDirectory() + "\\user.json");
            var client = new HttpClient();
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var result = await client.PostAsync("https://localhost:44342/api/auth/login", content);
            result.EnsureSuccessStatusCode();
            var body = await result.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<Tok>(body).token;
        }

    }
}
