using System.Threading.Tasks;

namespace AbpCaptcha
{
    public interface ICaptchaEngine
	{
		Task<CaptchaOutput> GetCaptcha();
        Task<CaptchaVerify> VerifyCaptcha(CaptchaInput input);
	}
}
