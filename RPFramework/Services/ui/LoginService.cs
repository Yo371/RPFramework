using System.Collections.Generic;
using Newtonsoft.Json;
using OpenQA.Selenium;
using RPFramework.Core;
using RPFramework.Core.Utils;
using RPFramework.Models.api;
using RPFramework.Models.ui;
using RPFramework.Pages;
using RPFramework.Services.api;

namespace RPFramework.Services.ui
{
    public class LoginService
    {
        private readonly LoginPage _loginPage = new LoginPage();
        private readonly RpPage _rpPage = new RpPage();

        public AllDashboardsPage Login(User user)
        {
            Wait.WhileElementMoving(_loginPage.LoginInput);
            _loginPage.LoginInput.SendKeys(user.UserName);
            _loginPage.PasswordInput.SendKeys(user.Password);
            _loginPage.LoginButton.Click();
            Wait.WhilePresented(_loginPage.NitificationContainer);
            return new AllDashboardsPage();
        }

        public void LoginViaApi(User user)
        {
            var restSharpService = new RestSharpService(RestSharpClientFactory.RestSharpReportPortalClient);
            var tokenFromLocalStorage = "...";
            var requestUrl = "http://localhost:8080/uat/sso/oauth/token";
            var headers = new Dictionary<string, string>()
            {
                { "Authorization", $"Basic {tokenFromLocalStorage}" }
            };
            var parameters = new Dictionary<string, string>()
            {
                { "grant_type", "password" },
                { "username", user.UserName },
                { "password", user.Password }
            };
            var response = restSharpService.PerformPostRequest(requestUrl, headers: headers, parameters: parameters);
            var accessTokenModel = JsonConvert.DeserializeObject<AccessTokenModel>(response.Content);
            var token = accessTokenModel.access_token;
            
            string accessTokenValue =
                @"{" + "\"type\"" + ":" + "\"bearer\"" + "," + "\"value\"" + ":" + $"\"{token}\"" + @"}";
            ((IJavaScriptExecutor)Browser.Instance).ExecuteScript($"localStorage.setItem(arguments[0],arguments[1])",
                "token", accessTokenValue);
            
            Browser.Instance.Navigate().Refresh();
        }

        public void LogoutViaApi()
        {
            ((IJavaScriptExecutor)Browser.Instance).ExecuteScript($"localStorage.clear()");
            Browser.Instance.Navigate().Refresh();
        }
    }
}