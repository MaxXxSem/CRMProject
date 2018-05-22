using System;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CRMProject.BLL.Services;
using CRMProject.DAL.Repositories;

namespace CRMProject.Tests.BLL
{
    [TestClass]
    public class ServicesTest
    {
        [TestMethod]
        public async Task ReportServiceTransactionsReport()
        {
            var trans = await new ReportService(new UnitOfWork()).GetTransactionsReport();
            Assert.IsNotNull(trans);
        }
    }
}
