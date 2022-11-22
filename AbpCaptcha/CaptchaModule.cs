using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Modularity;

namespace AbpCaptcha
{
    public class CaptchaModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            var configuration = context.Services.GetConfiguration();
            Configure<CaptchaOptions>(configuration.GetSection("Captcha"));
        }
    }
}
