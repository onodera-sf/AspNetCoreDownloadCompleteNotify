using DownloadCompleteNotifyMvc.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace DownloadCompleteNotifyMvc.Controllers
{
  public class HomeController : Controller
  {
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
      _logger = logger;
    }

    public IActionResult Index()
    {
      return View();
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

    /// <summary>時間をかけてファイルをダウンロードします。</summary>
    public async Task<IActionResult> Download()
    {
      // ダウンロード開始と完了を明確にする目的で待機を入れる
      await Task.Delay(5000);

      // 適当にファイルを作って返す
      var fileSize = 10_000_000;
      var sb = new System.Text.StringBuilder(fileSize);
      for (int i = 0; i < fileSize; i++) sb.Append('a');
      using var stream = new MemoryStream(System.Text.Encoding.UTF8.GetBytes(sb.ToString()));
      return File(stream.ToArray(), "text/plain", $"ダウンロード.txt");
    }
  }
}
