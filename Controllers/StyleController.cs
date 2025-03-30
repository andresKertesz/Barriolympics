using BarriolympicsRadzen.Helpers;

namespace BarriolympicsRadzen.Controllers
{
    public class StyleController
    {
        public string BodyStyle { get; set; } = "background: white";
        public event Action? OnStyleChanged;
        public void SetBackgroundGradient(string hexColor)
        {
            string baseColor = hexColor;
            string darker = ColorUtils.DarkenColor(hexColor,0.2f);
            string evenDarker = ColorUtils.DarkenColor(darker, 0.2f);

            BodyStyle = $"background: {evenDarker};background: linear-gradient(23deg, {evenDarker} 12%, {darker} 30%, {baseColor} 49%, rgba(255,255,255,1) 65%);";
            OnStyleChanged.Invoke();
        }
    }
}
