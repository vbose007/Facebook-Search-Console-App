using System.Threading.Tasks;

namespace FacebookApp
{
    public interface IFacebookService
    {
        Task<dynamic> SearchAsync(string accessToken, string searchString);
    }
}