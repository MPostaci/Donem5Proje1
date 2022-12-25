using System.Text;
using Newtonsoft.Json;
using AuthAPI.Models;

namespace AuthAPI
{
    public class AuthService
    {
        public static async Task<RegisterResponseModel?> Register(RegisterPostModel registerPostModel)
        {
            using (var client = new HttpClient())
            {
                var newPostJson = JsonConvert.SerializeObject(registerPostModel);
                StringContent payload = new StringContent(newPostJson, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await client.PostAsync("https://localhost:5000/api/Authenticate/register", payload);
                
                return JsonConvert.DeserializeObject<RegisterResponseModel>(await response.Content.ReadAsStringAsync());
            }
        }

        public static async Task<LoginResponseModel?> Login(LoginPostModel loginPostModel)
        {
            using (var client = new HttpClient())
            {
                var newPostJson = JsonConvert.SerializeObject(loginPostModel);
                StringContent payload = new StringContent(newPostJson, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await client.PostAsync("https://localhost:5000/api/Authenticate/login", payload);

                return JsonConvert.DeserializeObject<LoginResponseModel>(await response.Content.ReadAsStringAsync());
            }
        }
    }
}
