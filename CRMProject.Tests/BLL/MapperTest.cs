//using System;
//using System.Threading.Tasks;
//using Microsoft.VisualStudio.TestTools.UnitTesting;
//using CRMProject.BLL.Services;
//using CRMProject.DAL.Repositories;
//using System.Diagnostics;

//namespace CRMProject.Tests.BLL
//{
//    [TestClass]
//    public class MapperTest
//    {
//        [TestMethod]
//        public async Task TestMethod1()
//        {
//            AdminService admin = new AdminService(new UnitOfWork());
//            var users = await admin.GetUsers();
//            foreach (var user in users)
//            {
//                Console.WriteLine("----------------------------------");
//                Console.WriteLine(user.Id);
//                Console.WriteLine(user.UserName);
//                Console.WriteLine("----------------------------------");
//            }

//            Assert.IsNotNull(users);
//        }

//        [TestMethod]
//        public async Task TestMethod2()
//        {
//            ClientService client = new ClientService(new UnitOfWork());
//            var clients = await client.GetClients();
//            Assert.IsNotNull(clients);
//        }
//    }
//}
