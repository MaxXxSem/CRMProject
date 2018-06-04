using Ninject.Modules;
using CRMProject.BLL.Interfaces;
using CRMProject.BLL.Services;
using Ninject.Web.Common;

namespace CRMProject.Util
{
    public class BLLServicesModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IAccount>().To<AccountService>().InRequestScope();
            Bind<IAdmin>().To<AdminService>().InRequestScope();
            Bind<IClientService>().To<ClientService>().InRequestScope();
            Bind<IContactService>().To<ContactService>().InRequestScope();
            Bind<INotificationsService>().To<NotificationService>().InRequestScope();
            Bind<IReportService>().To<ReportService>().InRequestScope();
            Bind<ITaskService>().To<TaskService>().InRequestScope();
            Bind<ITransactionService>().To<TransactionService>().InRequestScope();
        }
    }
}