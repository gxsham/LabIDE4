using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Net.Http;

namespace LoLChamps.API
{
    public class GetChampInfo
    {
        
        static HttpClient httpClient = new HttpClient();
        public GetChampInfo()
        {

        }
        
        public static async Task<Champions> GetIds()
        {
            httpClient = new HttpClient();
            string unsanitizedjson = await httpClient.GetStringAsync("https://ru.api.pvp.net/api/lol/ru/v1.2/champion?api_key=7593f3d7-06f5-4cb7-b1c3-90f6edacd2ed");
            Champions xxx = JsonConvert.DeserializeObject<Champions>(unsanitizedjson);
            return xxx;
        }
        public static async Task<Champion> GetChamps(string id)
        {
            try
            {
                httpClient = new HttpClient();
                string result = await httpClient.GetStringAsync("https://global.api.pvp.net/api/lol/static-data/ru/v1.2/champion/" + id + "?locale=en_US&champData=image,lore&api_key=7593f3d7-06f5-4cb7-b1c3-90f6edacd2ed");
                Champion champ = JsonConvert.DeserializeObject<Champion>(result);
                return champ;
            }
            catch
            {
                return new Champion() { name = "Connection Error" };
            }
        }
    }
}
