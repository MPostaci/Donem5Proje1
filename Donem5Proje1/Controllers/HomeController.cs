using Donem5Proje1.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Text;
using AuthAPI;
using AuthAPI.Models;
using BlockchainAPI;
using BlockchainAPI.Models;
using System.Transactions;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Donem5Proje1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            var content = await BlockchainService.GetBlocks();
            ViewBag.Length = content?.Length;

            BlockPassModel blockPassModel = new BlockPassModel();

            List<string> hashes = new List<string>();
            List<DateTime> dateTimes = new List<DateTime>();
            List<string> dataList = new List<string>();

            for (int i = 1; i < content?.Length; i++)
            {
                DateTime dateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
                dateTime = dateTime.AddMilliseconds(Convert.ToDouble(content[i].timestamp));
                dateTimes.Add(dateTime);
                hashes.Add(content[i].hash);
                var data = JsonConvert.SerializeObject(content[i].data);
                dataList.Add(data);
            }

            blockPassModel.time = dateTimes;
            blockPassModel.hash = hashes;
            blockPassModel.data = dataList;

            return View(blockPassModel);
        }

        public async Task<IActionResult> Wallet()
        {
            var content = await BlockchainService.GetWalletInfo();

            ViewBag.Balance = content?.Balance;
            return View("Wallet", content);
        }

        public IActionResult Transact()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Transact(TransactPostModel transactPostModel)
        {
            var content = await BlockchainService.Transact(transactPostModel);

            return View("MineTransactions", content);
        }

        public IActionResult MineTransactions()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> MineTransacts()
        {
            var content = await BlockchainService.MineTransactions();

            return RedirectToAction("Index", "Home");

        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}