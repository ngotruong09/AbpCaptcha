using AbpCaptchaTest;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp;
using Volo.Abp.Threading;

using (var app = AbpApplicationFactory.Create<AbpCaptchaTestModule>(options =>
{
    var builder = new ConfigurationBuilder();
    builder.AddJsonFile("appsettings.json", false);
    options.Services.ReplaceConfiguration(builder.Build());
}))
{
    app.Initialize();
    var demo = app.ServiceProvider.GetRequiredService<ServiceDemo>();
    AsyncHelper.RunSync(() => demo.RunAsync());
    Console.WriteLine("Press ENTER to stop application...");
    Console.ReadLine();
}