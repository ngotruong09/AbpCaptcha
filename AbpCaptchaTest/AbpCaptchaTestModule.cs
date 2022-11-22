using AbpCaptcha;
using Volo.Abp.Autofac;
using Volo.Abp.Caching;
using Volo.Abp.Modularity;

namespace AbpCaptchaTest
{
    [DependsOn(
       typeof(AbpAutofacModule),
       typeof(AbpCachingModule),
       typeof(CaptchaModule)
    )]
    public class AbpCaptchaTestModule: AbpModule
    {
    }
}
