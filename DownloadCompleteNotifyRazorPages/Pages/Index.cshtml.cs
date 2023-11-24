using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DownloadCompleteNotifyRazorPages.Pages
{
  public class IndexModel : PageModel
  {
    private readonly ILogger<IndexModel> _logger;

    public IndexModel(ILogger<IndexModel> logger)
    {
      _logger = logger;
    }

    public void OnGet()
    {

    }

    /// <summary>時間をかけてファイルをダウンロードします。</summary>
    public async Task<IActionResult> OnGetDownload()
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
