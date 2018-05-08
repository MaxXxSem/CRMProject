using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ninject.Modules;
using CRMProject.DAL.Interfaces;
using CRMProject.DAL.Repositories;

namespace CRMProject.BLL.Infrastructure
{
    class NinjectServiceModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IUnitOfWork>().To<UnitOfWork>();
        }
    }
}
