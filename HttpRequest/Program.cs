using System;
using System.Net.Http;
using System.Threading.Tasks;

class Program
{
    static async Task Main(string[] args)
    {
        string url = "https://tarteeb-api-prod.azurewebsites.net/api/home/no-auth";
        _ = Task.Run(async () =>
        {
            using HttpClient client = new HttpClient();

            while (true)
            {
                try
                {
                    var response = await client.GetAsync(url);

                    if (response.IsSuccessStatusCode)
                    {
                        Console.WriteLine(
                            $"[{DateTime.Now:HH:mm:ss}] Tarteeb running without auth...");
                    }
                    else
                    {
                        Console.WriteLine(
                            $"[{DateTime.Now:HH:mm:ss}] API error: {response.StatusCode}");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(
                        $"[{DateTime.Now:HH:mm:ss}] API not reachable: {ex.Message}");
                }
                await Task.Delay(5000);
            }
        });

        Console.WriteLine("Heartbeat ishga tushdi. To'xtatish uchun ENTER bosing...");
        Console.ReadLine();
    }
}
