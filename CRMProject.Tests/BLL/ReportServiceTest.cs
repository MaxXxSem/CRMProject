using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CRMProject.DAL.Repositories;
using CRMProject.BLL.Services;
using CRMProject.BLL.DTO;
using System.Linq;
using System.Threading.Tasks;

namespace CRMProject.Tests.BLL
{
    [TestClass]
    public class ReportServiceTest
    {
        [TestMethod]
        public async Task GetManagersReport()
        {
            var report = await new ReportService(new UnitOfWork()).GetManagersReport();
            Assert.IsTrue(report != null && report.Count() > 0);
        }

        [TestMethod]
        public async Task GetTransactionsReport()
        {
            var report = await new ReportService(new UnitOfWork()).GetTransactionsReport();
            Assert.IsTrue(report != null && report.Count() > 0);
        }
    }
}
