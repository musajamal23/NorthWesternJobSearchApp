using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using JobSearchingApp.Model;
namespace JobSearchingApp.Controllers
{
    [Route("api/[controller]")]
    public class JobSearchController : Controller
    {
        static List<JobsModel> jobs = new List<JobsModel>();
        static HttpClient client = new HttpClient();

        [HttpGet("[action]")]
        public async Task<IEnumerable<JobsModel>> JobSearches()
        {
            return await GetRequest("https://jobs.github.com/positions.json");
        }

        async static Task<List<JobsModel>> GetRequest(string url)
        {
            using (HttpClient client = new HttpClient())
            {
                using (HttpResponseMessage responseMessage = await client.GetAsync(url))
                {
                    using (HttpContent content = responseMessage.Content)
                    {
                        using (WebClient wc = new WebClient())
                        {
                            var json = wc.DownloadString(url);
                            return JsonConvert.DeserializeObject<List<JobsModel>>(json);

                        }

                    }
                }

            }
        }
    }
}