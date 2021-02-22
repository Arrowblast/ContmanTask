
using ContmanTask.BussinessLogic.DataContact.Account;
using ContmanTask.BussinessLogic.DataContact.Mail;
using ContmanTask.WebApi_Controllers;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;



namespace ContmanTaskTests.WebApi_Controllers
{
    [TestClass]
    public class MailerControllerTest
    {
        private string token;
        public MailerControllerTest()
        {
            token = new AccountController().GetToken();
            token = token.Split(',')[0].Split(':')[1].Trim('\"');
        }
        [TestMethod]
        public void IsNotAuthorized()
        {
            var client = new RestClient("https://localhost:5001/api/Mailer/GetAllMail");
            var request = new RestRequest(Method.GET);
            request.AddHeader("content-type", "application/json");
            var response = client.Execute(request);
            Assert.AreEqual(HttpStatusCode.Unauthorized, response.StatusCode);
        }
        [TestMethod]
        public void IsAuthorized()
        {
            var client = new RestClient("https://localhost:5001/api/Mailer/GetAllMail");
            var request = new RestRequest(Method.GET);
            request.AddHeader("content-type", "application/json");
            request.AddHeader("Authorization", string.Format("Bearer {0}", token));
            var response = client.Execute(request);
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        }
        #region niewykorzystane
        //[TestMethod()]
        public void GetMailTest()
        {
            var getMail = "https://localhost:5001/api/Mailer/GetMail";
            var addMail = "https://localhost:5001/api/Account/CreateAccount";
            var randMail = Guid.NewGuid().ToString();
            var randAccount = Guid.NewGuid().ToString();
            var mailDataRequest = new MailDataRequest()
            {
                Mail = randMail,
                AccountName = randAccount,
                GroupId = 0
            };
            var accountDataRequest = new AccountDataRequest()
            {
                AccountName = randAccount,
                Email = randMail
            };
            var request = this.CreateRequest< MailDataRequest >(Method.GET,mailDataRequest);
            var client = new RestClient(getMail);
            var response = client.Execute(request);
            Assert.IsTrue(response.Content.Length==0);
            client.BaseUrl = new Uri(addMail);
            request = this.CreateRequest<AccountDataRequest>(Method.POST, accountDataRequest);
            client.Execute(request);
            client.BaseUrl = new Uri(getMail);
            request = this.CreateRequest<MailDataRequest>(Method.GET,mailDataRequest);
            response = client.Execute(request);
            Assert.IsTrue(response.Content.Length > 0);

        }
        private IRestRequest CreateRequest<T>(RestSharp.Method method , T body)
        {
            var request = new RestRequest(method);
            request.AddHeader("content-type", "application/json");
            request.AddHeader("Authorization", string.Format("Bearer {0}", token));
            request.AddJsonBody(body);
            return request;
        }
        #endregion
    }
}
