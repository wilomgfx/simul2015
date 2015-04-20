using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;

namespace Lab10.DAL
{
    interface IUnitOfWork : IDisposable
    {
        void Save();
    }
}