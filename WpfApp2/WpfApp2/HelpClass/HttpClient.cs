using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using WpfApp2.DataBase;

namespace WpfApp2.HelpClass
{
    class HelpHttpClient
    {

        public static string GETCLIENTS = "https://localhost:44313/api/Clients";
        static HttpClient http = new HttpClient();

        public static async Task<List<Clients>> getList(string url)
        {
            var result = await (await http.GetAsync(url)).Content.ReadAsStringAsync();
            var json = JsonSerializer.Deserialize<List<Clients>>(result);

            return json;
        }
    }
}
