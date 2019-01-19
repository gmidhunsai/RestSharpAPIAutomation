using System;
using System.Net;
using System.Diagnostics;
using Xunit;
using RestSharp;
using FluentAssertions;
using Newtonsoft.Json;

using Models;
using Library;

namespace API_Automation_Framework
{
    public class LoginValidationScenarios
    {
        [Fact]
        public void validateCorrectLogin()
        {
            Debug.WriteLine("****** Running test : Validate login with valid credentials ******");
            // Construct request from Request models
            LoginPhoneRequest loginPhoneRequest = new LoginPhoneRequest();
            loginPhoneRequest.MobilePhoneNumber = "9876543211";
            loginPhoneRequest.Pin = "1234";
            loginPhoneRequest.Language = "en";
            loginPhoneRequest.System = "QAPZNSVC01";
            loginPhoneRequest.Username = "PersonalizationRestSharpAutomation";
            
            // API Call
            RestServices restServices = new RestServices();
            IRestResponse response = restServices.postLoginPhone(loginPhoneRequest);
            var parsedResponse = JsonConvert.DeserializeObject<LoginPhoneResponse>(response.Content);

            // Assertions
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            parsedResponse.MobilePhoneNumber.Should().Be("9876543211");
        }
    }
}
