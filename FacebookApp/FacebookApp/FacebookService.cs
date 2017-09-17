using System.Threading.Tasks;

namespace FacebookApp
{
    public class FacebookService : IFacebookService
    {
        private readonly IFacebookClient _ifbClient;

        public FacebookService(IFacebookClient ifbClient)
        {
            _ifbClient = ifbClient;
        }

        public async Task<dynamic> SearchAsync(string accessToken, string searchString)
        {
            var result = await _ifbClient.SearchAsync<dynamic>(
                accessToken, searchString, "search", "fields=id,name,email,first_name,last_name,age_range,birthday,gender,locale,picture");

            return result;

            //if (result == null)
            //{
            //    return new Account();
            //}

            //var account = new Account
            //{
            //    Profile_Id = result.id,
            //    Email = result.email,
            //    Name = result.name,
            //    UserName = result.username,
            //    FirstName = result.first_name,
            //    LastName = result.last_name,
            //    Locale = result.locale
            //};

            //return account;
        }
    }
}