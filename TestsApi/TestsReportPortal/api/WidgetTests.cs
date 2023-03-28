using System.Net;
using NUnit.Framework;
using RPFramework.Core;
using RPFramework.Models.api.WigdetRelated;

namespace TestsApi.TestsReportPortal.api
{
    [TestFixture]
    public class WidgetTests : BaseTest
    {
        private Widget _postedWidget = ApiModelsFactory.GetPredefinedWidget();
        
        [Test, Order(1)]
        public void CheckCreatingWidget()
        {
            Assert.AreEqual(HttpStatusCode.Created, WidgetApiService.PostWidget(_postedWidget).StatusCode);
            Assert.AreEqual(_postedWidget, WidgetApiService.GetWidget(_postedWidget));
        }
        
        [Test, Order(2)]
        public void CheckUpdatingWidget()
        {
            _postedWidget.description = "new description check";
            Assert.AreEqual(HttpStatusCode.OK, WidgetApiService.UpdateWidget(_postedWidget).StatusCode);
            Assert.AreEqual(_postedWidget, WidgetApiService.GetWidget(_postedWidget));
        }
        
        [Test, Order(3)]
        public void CheckDeletingWidget()
        {
            Assert.AreEqual(HttpStatusCode.OK, WidgetApiService.DeleteWidget(_postedWidget).StatusCode);
            Assert.AreEqual(0, WidgetApiService.GetWidget(_postedWidget).id);
        }
    }
}