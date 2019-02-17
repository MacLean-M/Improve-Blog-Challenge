using System.Threading.Tasks;
using static SimpleBlog.FrontEnd.Infrastructure.WebClient;

namespace SimpleBlog.FrontEnd.Infrastructure 
{
    public interface IWebClient
    {
        EnumEntityType EntityType { get; set; }

        Task<string> GetData(string suffix = "");
    }
}