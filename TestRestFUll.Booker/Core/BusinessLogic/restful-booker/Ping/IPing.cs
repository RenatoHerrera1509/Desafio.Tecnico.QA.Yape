using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.restful_booker.Ping
{
    public interface IPing
    {
        Task<bool> HealthCheckAsync();
    }
}
