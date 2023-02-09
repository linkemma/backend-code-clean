using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tienda.Entities.Interfaces;
using Tienda.Repositories.EFCore.DataContext;

namespace Tienda.Repositories.EFCore.Repositories
{
    public class UnitiOfWork : IUnitiOfWork
    {
        readonly TiendaContext _context;
        public UnitiOfWork(TiendaContext context)
        {
            _context = context;
        }

        public Task<int> SaveChangesAsync()
        {
            return _context.SaveChangesAsync();
        }
    }
}
