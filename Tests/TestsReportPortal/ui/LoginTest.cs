using System;
using NUnit.Framework;
using RPFramework.Core.Attributes;
using RPFramework.Core.Enums;
using RPFramework.Models.ui;
using RPFramework.Services.api;

namespace Tests.TestsReportPortal.ui
{
    internal class LoginTest : BaseTest
    {
        private string _taskName = "FIRST-1";
        
        [SetUp]
        public void MoveJiraTicketBeforeRun()
        {
            JiraApiService.MoveJiraTicket(_taskName, JiraStatus.InProgress);
            SlackApiService.SendMessage("Login tests started... " + DateTime.Now);
        }
        
        [Test, Smoke]
        public void CheckUserIsLoggedIn()
        {
            LoginService.Login(UserFactory.GetAdminUser());

            Assert.IsTrue(RpPage.SideBar.UserBlock.Displayed, "User block is not displayed after log in!");
            Assert.AreEqual(ExpectedDashBoardText, AllDashboardsPage.Title, "Dashboard page is not opened!");
        }
        
        [TearDown]
        public void MoveJiraTicketAfterRun()
        {
            JiraApiService.MoveJiraTicket(_taskName, JiraStatus.Done);
            SlackApiService.SendMessage("Login tests finished... " + DateTime.Now + " with status: " + TestContext.CurrentContext.Result.Outcome.Status);
        }
    }
}
