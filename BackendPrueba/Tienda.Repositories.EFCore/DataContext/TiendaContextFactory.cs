using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tienda.Repositories.EFCore.DataContext
{
    class TiendaContextFactory : IDesignTimeDbContextFactory<TiendaContext>
    {
        public TiendaContext CreateDbContext(string[] args)
        {
            var OptionBuilder = new DbContextOptionsBuilder<TiendaContext>();
            OptionBuilder.UseSqlServer(
                    "Data Source=DESKTOP-3HCCFCQ;Integrated Security=True;" +
                    "Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;" +
                    "ApplicationIntent=ReadWrite;MultiSubnetFailover=False;" +
                    "Database=TiendaOphelia"
                );
            return new TiendaContext(OptionBuilder.Options);
        }
    }
}
