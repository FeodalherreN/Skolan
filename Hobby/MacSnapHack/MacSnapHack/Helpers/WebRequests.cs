using System;
using System.Web;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Http;

namespace MacSnapHack
{
    public static class WebRequests
    {
        public static async Task<HttpResponseMessage> Post(string endpoint, Dictionary<string, string> postData,
            string typeToken, string timeStamp, Dictionary<string, string> headers = null)
        {
            var webClient = new HttpClient();
            webClient.DefaultRequestHeaders.TryAddWithoutValidation("User-Agent", KeyVault.UserAgent);
            webClient.DefaultRequestHeaders.TryAddWithoutValidation("Content-Length", "160");
            webClient.DefaultRequestHeaders.TryAddWithoutValidation("Accept", "*/*");
            webClient.DefaultRequestHeaders.TryAddWithoutValidation("Accept-Encoding", "gzip,deflate");

            if (headers != null)
                foreach (var header in headers)
                    webClient.DefaultRequestHeaders.TryAddWithoutValidation(header.Key, header.Value);

            postData["req_token"] = Tokens.GenerateRequestToken(typeToken, timeStamp);
            postData["version"] = "8.1.0";
            string postBody = PostBodyParser(postData);
            HttpResponseMessage response =
                await
                    webClient.PostAsync(new Uri(KeyVault.ApiBasePoint + endpoint),
                        new StringContent(postBody, Encoding.UTF8, "application/x-www-form-urlencoded"));
            return response;
        }

        public static string PostBodyParser(Dictionary<string, string> postEntries)
        {
            bool first = true;
            string output = "";
            foreach (var postEntry in postEntries)
            {
                if (!first)
                    output += string.Format("&{0}={1}", postEntry.Key, HttpUtility.UrlEncode(postEntry.Value));
                else
                    output += string.Format("{0}={1}", postEntry.Key, HttpUtility.UrlEncode(postEntry.Value));

                first = false;
            }

            return output;
        }
	}
}
