using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tienda.Entities.Interfaces
{
    public interface IUnitiOfWork
    {
        Task<int> SaveChangesAsync();
    }
}
