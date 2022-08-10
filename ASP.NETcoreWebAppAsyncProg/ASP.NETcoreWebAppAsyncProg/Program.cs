using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.IO;

namespace ASP.NETcoreWebAppAsyncProg
{
    internal class Program
    {
        static readonly HttpClient client = new HttpClient();

        static async Task Main()
        {
            for (int postId = 4; postId <= 13; postId++)
            {
                string emptyString = string.Empty;
                string getPosts =
                    await client.GetStringAsync("https://jsonplaceholder.typicode.com/posts/" + postId);
                getPosts = getPosts.Replace("\"userId\": ", "");
                getPosts = getPosts.Replace("\"id\": ", "");
                getPosts = getPosts.Replace("\"title\": ", "");
                getPosts = getPosts.Replace("\"body\": ", "");

                try
                {
                    StreamWriter sw = new StreamWriter("result.txt", true);
                    sw.WriteLine(getPosts);
                    sw.WriteLine(emptyString);
                    sw.Close();
                }
                catch (Exception e)
                {
                    Console.WriteLine("Exception: " + e.Message);
                }
                finally
                {
                    Console.WriteLine($"Запись поста {postId} завершена");
                }
            }
        }
    }
}
