using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TYS_WIM_REPORT.Interfaces
{
    public interface IRepositoryUpdateCommand<TEntity>
    {
        public int Update(TEntity entity);
    }
}
