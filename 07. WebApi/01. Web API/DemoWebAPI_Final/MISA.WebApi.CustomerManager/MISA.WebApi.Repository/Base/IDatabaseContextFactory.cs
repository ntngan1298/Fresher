using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.WebApi.Repository
{
    public interface IDatabaseContextFactory
    {
        IDatabaseContext Context();
    }
}
