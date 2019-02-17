using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace SimpleBlog.API.Infrastructure 
{
    public class WebClient : IWebClient
    {
        #region "Props"
        
        public enum EnumEntityType 
        {
            posts = 1,
            comments = 2
        }

        public EnumEntityType EntityType { get; set; }

        public readonly HttpClient _httpClient;
        
        #endregion

        #region "Methods"

        public WebClient(HttpClient httpClient) 
        {
            _httpClient = httpClient;
        }

        public async Task<string> GetData(string suffix = "") 
        {
            var address = "http://jsonplaceholder.typicode.com/" + GetPathFromEntityType() + suffix;

            return await _httpClient.GetStringAsync(address);
        }

        private string GetPathFromEntityType()
        {
            switch(EntityType)
            {
                default:
                case EnumEntityType.posts:
                    return "posts";

                case EnumEntityType.comments:
                    return "comments?postId=";
            }
        }

        #endregion
    }
}