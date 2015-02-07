using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YoutubeDownloader
{
    public class SnippetResult
    {
        [JsonProperty("kind")]
        public string kind { get; set; }
        [JsonProperty("etag")]
        public string etag { get; set; }
        [JsonProperty("nextPageToken")]
        public string nextPageToken { get; set; }
        [JsonProperty("pageInfo")]
        public PageInfo pageInfo { get; set; }
        [JsonProperty("items")]
        public List<Item> items { get; set; }
    }
    public class PageInfo
    {
        [JsonProperty("totalResults")]
        public int totalResults { get; set; }
        [JsonProperty("resultsPerPage")]
        public int resultsPerPage { get; set; }
    }
    public class Item
    {
        [JsonProperty("kind")]
        public string kind { get; set; }
        [JsonProperty("etag")]
        public string etag { get; set; }
        [JsonProperty("id")]
        public Id id { get; set; }
        [JsonProperty("snippet")]
        public Snippet snippet { get; set; }
    }
    public class Snippet
    {
        [JsonProperty("publishedAt")]
        public string publishedAt { get; set; }
        [JsonProperty("channelId")]
        public string channelId { get; set; }
        [JsonProperty("title")]
        public string title { get; set; }
        [JsonProperty("description")]
        public string description { get; set; }
        [JsonProperty("thumbnails")]
        public Thumbnails thumbnails { get; set; }
        [JsonProperty("channelTitle")]
        public string channelTitle { get; set; }
        [JsonProperty("liveBroadcastContent")]
        public string liveBroadcastContent { get; set; }
    }
    public class Thumbnails
    {
        [JsonProperty("default")]
        public Default defaultt { get; set; }
        [JsonProperty("medium")]
        public Medium medium { get; set; }
        [JsonProperty("high")]
        public High high { get; set; }
    }
    public class Default
    {
        [JsonProperty("url")]
        public string url { get; set; }
    }
    public class Medium
    {
        [JsonProperty("url")]
        public string url { get; set; }
    }
    public class High
    {
        [JsonProperty("url")]
        public string high { get; set; }
    }
    public class Id
    {
        [JsonProperty("kind")]
        public string kind { get; set; }
        [JsonProperty("videoId")]
        public string videoId { get; set; }
    }
}
