using AbpCaptcha;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace AbpCaptchaTest
{
    public class ServiceDemo: ITransientDependency
    {
        private readonly ICaptchaEngine _captchaEngine;

        public ServiceDemo(ICaptchaEngine captchaEngine)
        {
            _captchaEngine = captchaEngine;
        }

        public async Task RunAsync()
        {
            var captcha = await _captchaEngine.GetCaptcha();

            Console.WriteLine(captcha.Token);
            Console.WriteLine(captcha.Base64Value);

            Console.WriteLine("Token=");
            var token = Console.ReadLine();
            Console.WriteLine("Captcha=");
            var captchaStr = Console.ReadLine();

            var res = await _captchaEngine.VerifyCaptcha(new CaptchaInput { Captcha = captchaStr, Token = token });
            Console.WriteLine(res.Message);
            Console.WriteLine(res.IsValid);
        }
    }
}
