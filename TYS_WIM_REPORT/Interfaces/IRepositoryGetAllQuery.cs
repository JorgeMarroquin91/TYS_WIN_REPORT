﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TYS_WIM_REPORT.Interfaces
{
    public interface IRepositoryGetAllQuery<TEntity>
    {
        public IList<TEntity> GetAll();
    }
}