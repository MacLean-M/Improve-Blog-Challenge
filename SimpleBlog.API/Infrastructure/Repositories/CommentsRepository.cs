using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using static SimpleBlog.API.Infrastructure.WebClient;

namespace SimpleBlog.API.Infrastructure 
{
    public class CommentsRepository : ICommentsRepository 
    {
        public static IWebClient _client;

        public CommentsRepository(IWebClient client)
        {
            _client = client;
        }

        public async Task<IList<Comment>> GetN<Comment>(int postId, int count)
        {
            var comments = await GetAll<Comment>(postId);
            return comments.Take(count).ToList();
        }

        public async Task<IList<Comment>> GetAll<Comment>(int postId)
        {
            _client.EntityType = EnumEntityType.comments;
            var json = await _client.GetData(postId + "");

            var commentList = new List<Comment>();

            foreach (JObject i in JArray.Parse(json))
            {
                var jArray = new List<JObject>();

                foreach (JObject j in i.Root)
                {
                    var comment = j.ToObject<Comment>();
                    commentList.Add(comment);
                }
            }
            
            return commentList;
        }
    }
}