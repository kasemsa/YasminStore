using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YasminStore.ApplicationContract.Identity
{
    public interface IJwtTokenService
    {
        string GenerateToken(string userId, string email, string role);
    }
}
