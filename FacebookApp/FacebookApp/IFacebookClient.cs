using System.Threading.Tasks;

namespace FacebookApp
{
    public interface IFacebookClient
    {
        Task<T> SearchAsync<T>(string accessToken, string searchString, string endpoint, string args = null);
    }
}