using SixLabors.Fonts;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Formats;

namespace AbpCaptcha
{
    public class CaptchaOptions
    {
        public string[] FontFamilies { get; set; }
        public Color[] TextColor { get; set; } = new Color[] { Color.Blue, Color.Black, Color.Black, Color.Brown, Color.Gray, Color.Green };
        public Color[] DrawLinesColor { get; set; } = new Color[] { Color.Blue, Color.Black, Color.Black, Color.Brown, Color.Gray, Color.Green };
        public float MinLineThickness { get; set; } = 0.7f;
        public float MaxLineThickness { get; set; } = 2.0f;
        public ushort Width { get; set; } = 180;
        public ushort Height { get; set; } = 50;
        public ushort NoiseRate { get; set; } = 800;
        public Color[] NoiseRateColor { get; set; } = new Color[] { Color.Gray };
        public byte FontSize { get; set; } = 29;
        public FontStyle FontStyle { get; set; } = FontStyle.Regular;
        public EncoderTypes EncoderType { get; set; } = EncoderTypes.Png;
        public IImageEncoder Encoder => Extentions.GetEncoder(EncoderType);
        public byte DrawLines { get; set; } = 3;
        public byte MaxRotationDegrees { get; set; } = 5;

        public int Timeout { get; set; } = 30; // second
        public int SizeText { get; set; } = 6;
        public string Pattern { get; set; } = "123456789";
        public char[] Patterns
        {
            get
            {
                return Pattern.ToCharArray();
            }
        }
    }
}
