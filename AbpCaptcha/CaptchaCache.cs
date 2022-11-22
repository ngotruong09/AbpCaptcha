using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Options;
using System;
using System.Threading.Tasks;
using Volo.Abp.Caching;
using Volo.Abp.DependencyInjection;

namespace AbpCaptcha
{
    public class CaptchaCacheHandle: ITransientDependency
    {
        private readonly IDistributedCache<CaptchaCache> _memoryCache;
        private readonly CaptchaOptions _options;

        public CaptchaCacheHandle(IDistributedCache<CaptchaCache> memoryCache, IOptions<CaptchaOptions> options)
        {
            _memoryCache = memoryCache;
            _options = options.Value;
        }

        public async Task SetCache(string guid, string captcha)
        {
            var cache = new CaptchaCache
            {
                Captcha = captcha
            };
            await _memoryCache.SetAsync(
                      guid, cache,
                      new DistributedCacheEntryOptions
                      {
                          AbsoluteExpiration = DateTimeOffset.Now.AddSeconds(_options.Timeout)
                      });
        }

        public async Task<string> GetCache(string guid)
        {
            var cache = await _memoryCache.GetAsync(guid);
            return cache?.Captcha;
        }

        public void RemoveCache(string guid)
        {
            _memoryCache.Remove(guid);
        }
        
        public async Task<bool> IsExists(string guid)
        {
            var cache = await _memoryCache.GetAsync(guid);
            if(cache != null)
            {
                return true;
            }
            return false;
        }
    }
}
