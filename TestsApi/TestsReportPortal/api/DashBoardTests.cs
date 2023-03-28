using System.Net;
using NUnit.Framework;
using RPFramework.Core;
using RPFramework.Models.api.DashboardRelated;

namespace TestsApi.TestsReportPortal.api
{
    [TestFixture]
    public class DashBoardTests : BaseTest
    {
        private Dashboard _postedDashboard = ApiModelsFactory.GetPredefinedDashboard();
        
        [Test, Order(1)]
        public void CheckCreatingDashboard()
        {
            Assert.AreEqual(HttpStatusCode.Created, DashBoardApiService.PostDashboard(_postedDashboard).StatusCode);
        }

        [Test, Order(2)]
        public void CheckReadingDashboard()
        {
            Assert.AreEqual(_postedDashboard, DashBoardApiService.GetDashboard(_postedDashboard));
        }
        
        [Test, Order(3)]
        public void CheckUpdatingDashboard()
        {
            _postedDashboard.Name = "updated name";
            Assert.AreEqual(HttpStatusCode.OK, DashBoardApiService.UpdateDashboard(_postedDashboard).StatusCode);
            Assert.AreEqual(_postedDashboard, DashBoardApiService.GetDashboard(_postedDashboard));
        }
        
        [Test, Order(4)]
        public void CheckDeletingDashboard()
        {
            Assert.AreEqual(HttpStatusCode.OK, DashBoardApiService.DeleteDashboard(_postedDashboard).StatusCode);
            Assert.AreEqual(0, DashBoardApiService.GetDashboard(_postedDashboard).Id);
        }
    }
}