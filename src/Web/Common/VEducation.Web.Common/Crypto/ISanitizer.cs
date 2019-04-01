using Abp.Application.Services;

namespace Education.Web.Common.Crypto
{
    public interface ISanitizer : IApplicationService
    {
        string Sanitize(string html);
    }
}