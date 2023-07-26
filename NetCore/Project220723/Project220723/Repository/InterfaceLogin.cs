using Project220723.Models;

namespace Project220723.Repository
{
    public interface InterfaceLogin
    {
        public string GetCredentials(Credentials cred);

        public ResponseModel GenerateJSONWebToken(string Username);
    }
}
