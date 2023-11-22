using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerTrackingService.Application.Contracts
{
    public interface IAuthorizeService
    {
        Task<TokenAuthDto> GetTokenByCode(CallbackAuthDto dto);
    }

    public class CallbackAuthDto
    {
        public string State { get; set; }
        public string AuthCode { get; set; }
    }

    public class TokenAuthDto
    {
        public string AccessToken { get; set; }

    }
}
