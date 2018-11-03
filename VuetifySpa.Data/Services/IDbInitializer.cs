using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace VuetifySpa.Data.Services
{
    public interface IDbInitializer
    {
        Task Initialize();
    }
}
