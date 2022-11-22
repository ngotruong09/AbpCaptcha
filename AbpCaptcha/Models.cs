namespace AbpCaptcha
{
    public class CaptchaVerify
    {
        public bool IsValid { get; set; }
        public string Message { get; set; }
    }

    public class CaptchaOutput
    {
        public string Token { get; set; }
        public string Base64Value { get; set; }
        public byte[] Bytes { get; set; }
    }

    public class CaptchaInput
    {
        public string Token { get; set; }
        public string Captcha { get; set; }
    }

    public class CaptchaCache
    {
        public string Captcha { get; set; }
    }
}
