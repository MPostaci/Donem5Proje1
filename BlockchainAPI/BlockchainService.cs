using System.Text;
using BlockchainAPI.Models;
using Newtonsoft.Json;

namespace BlockchainAPI
{
    public class BlockchainService
    {
        public static async Task<BlocksResponseModel[]?> GetBlocks()
        {
            using (var client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync("http://localhost:3000/api/Blocks");

                return JsonConvert.DeserializeObject<BlocksResponseModel[]>(await response.Content.ReadAsStringAsync());
            }
        }

        public static async Task<WalletInfoResponseModel?> GetWalletInfo()
        {
            using (var client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync("http://localhost:3000/api/wallet-info");

                return JsonConvert.DeserializeObject<WalletInfoResponseModel>(await response.Content.ReadAsStringAsync());
            }
        }

        public static async Task<TransactResponseModel?> Transact(TransactPostModel transactPostModel)
        {
            using (var client = new HttpClient())
            {
                var newPostJson = JsonConvert.SerializeObject(transactPostModel);
                StringContent payload = new StringContent(newPostJson, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await client.PostAsync("http://localhost:3000/api/transact", payload);

                return JsonConvert.DeserializeObject<TransactResponseModel>(await response.Content.ReadAsStringAsync());
            }
        }

        public static async Task<BlocksResponseModel[]?> MineTransactions()
        {
            using (var client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync("http://localhost:3000/api/mine-transactions");

                return JsonConvert.DeserializeObject<BlocksResponseModel[]?>(await response.Content.ReadAsStringAsync());
            }
        }

    }
}