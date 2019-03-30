using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace ConferenceApi.Schemas
{
    public class ContextProvider : IContextProvider
    {
        private readonly IHttpContextAccessor _contextAccessor;
        public ContextProvider(IHttpContextAccessor contextAccessor)
        {
            _contextAccessor = contextAccessor;
        }

        public T Get<T>()
        {
            if (_contextAccessor?.HttpContext?.RequestServices == null)
            {
                return default(T);
            }
            return _contextAccessor.HttpContext.RequestServices.GetService<T>();
        }
    }
}
