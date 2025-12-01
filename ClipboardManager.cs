using System.Threading.Tasks;
using System.Windows.Forms;

namespace SODV2202_Final
{
    public class ClipboardManager
    {
        public async Task CopyToClipboardAsync(string text, int autoClearSeconds = 10)
        {
            if (string.IsNullOrEmpty(text))
                return;

            Clipboard.SetText(text);

            await Task.Delay(autoClearSeconds * 1000);

            if (Clipboard.GetText() == text)
            {
                Clipboard.Clear();
            }
        }
    }
}
