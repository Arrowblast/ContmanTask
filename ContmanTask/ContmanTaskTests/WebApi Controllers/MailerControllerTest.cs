
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
            var token = new AccountController().GetToken();
            token = token.Split(',')[0].Split(':')[1].Trim('\"');
            request.AddHeader("Authorization", string.Format("Bearer {0}", token));
            var response = client.Execute(request);
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        }
    }
}
