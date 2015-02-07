using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Google.GData.YouTube;
using Google.YouTube;
using System.Net;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace YoutubeDownloader
{
    public class Search
    {
        private SnippetResult result;
        public SnippetResult searchForVideo(string Query)
        {
            result = new SnippetResult();
            using (var webClient = new System.Net.WebClient())
            {
                var json = webClient.DownloadString("https://www.googleapis.com/youtube/v3/search?part=snippet&maxResults=30&order=relevance&q=" + Query + "&key=AIzaSyCq-5680Ossq0ogxyBpwO3GF0Xp3Qu_b-k");
                // Now parse with JSON.Net
                var test = json.ToString();
                dynamic stuff = JsonConvert.DeserializeObject(json);
                result = JsonConvert.DeserializeObject<SnippetResult>(test);
            }
            return result;
        }
    }
}
