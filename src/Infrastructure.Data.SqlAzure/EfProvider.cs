using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data.SqlAzure
{
    public class EfProvider
    {
        public static PocFunDbContext GetContext()
        {
            return new PocFunDbContext();
        }
    }
}
