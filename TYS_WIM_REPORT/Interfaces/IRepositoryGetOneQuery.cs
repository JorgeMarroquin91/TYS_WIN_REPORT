using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace TYS_WIM_REPORT.Interfaces
{
    public interface IRepositoryGetOneQuery<TEntity>
    {
        public TEntity GetOne<T>(T id);
    }
}
