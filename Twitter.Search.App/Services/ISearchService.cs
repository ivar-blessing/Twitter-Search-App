using System.Threading.Tasks;

namespace Twitter.Search.App.Services
{
    public interface ISearchService
    {
        Task<string> GetData(string q);
    }
}