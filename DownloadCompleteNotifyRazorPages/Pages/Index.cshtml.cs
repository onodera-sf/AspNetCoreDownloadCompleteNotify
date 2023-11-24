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

    /// <summary>���Ԃ������ăt�@�C�����_�E�����[�h���܂��B</summary>
    public async Task<IActionResult> OnGetDownload()
    {
      // �_�E�����[�h�J�n�Ɗ����𖾊m�ɂ���ړI�őҋ@������
      await Task.Delay(5000);

      // �K���Ƀt�@�C��������ĕԂ�
      var fileSize = 10_000_000;
      var sb = new System.Text.StringBuilder(fileSize);
      for (int i = 0; i < fileSize; i++) sb.Append('a');
      using var stream = new MemoryStream(System.Text.Encoding.UTF8.GetBytes(sb.ToString()));
      return File(stream.ToArray(), "text/plain", $"�_�E�����[�h.txt");
    }
  }
}
