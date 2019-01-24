using System;
using System.Net;
using System.Diagnostics;
using Xunit;
using RestSharp;
using FluentAssertions;
using Newtonsoft.Json;
using Utils;
using Microsoft.Extensions.Configuration;
using Models;
using Library;

namespace Personalization_Service_Automation
{
    public class LoginValidationScenarios
    {
        // Initiating Rest Services
        RestServices restServices = new RestServices();

        /*Login Phone Positive scenario */
        [Fact]
        public void validateCorrectLoginPhone()
        {
            Debug.WriteLine("****** Running test : Validate login with valid credentials ******");

            // Construct request from Request models
            LoginPhoneRequest loginPhoneRequest = new LoginPhoneRequest();
            loginPhoneRequest.MobilePhoneNumber = ConfigurationReader.Get("Environment:QA:UserPhone");
            loginPhoneRequest.Pin =ConfigurationReader.Get("Environment:QA:UserPin");
            loginPhoneRequest.Language = "en";
            loginPhoneRequest.System = ConfigurationReader.Get("Environment:QA:System");
            loginPhoneRequest.Username = "PersonalizationRestSharpAutomation";

            // API Call
            IRestResponse response = restServices.postLoginPhone(loginPhoneRequest);
            var parsedResponse = JsonConvert.DeserializeObject<LoginResponse>(response.Content);

            // Assertions
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            parsedResponse.MobilePhoneNumber.Should().Be("9876543211");
        }

        /*Login Phone Negative scenarios */

        [Theory]        
        [InlineData("9876543211", "1235", HttpStatusCode.OK, "InvalidPassword")]
        [InlineData("1234557890", "1235", HttpStatusCode.OK, "AccountDoesNotExist")]
        [InlineData("123455789", "1235", HttpStatusCode.BadRequest, "The POSTed request body failed validation.")]
        [InlineData("1234557890", "123", HttpStatusCode.BadRequest, "The POSTed request body failed validation.")]
        [InlineData("123455789", "123", HttpStatusCode.BadRequest, "The POSTed request body failed validation.")]
        public void validateIncorrectLoginPhone(string phoneNumber, string pin, HttpStatusCode statusCode, string errorDescription)
        {
            Debug.WriteLine("****** Running test : Validate login with Invalid credentials ******");
            // Construct request from Request models
            LoginPhoneRequest loginPhoneRequest = new LoginPhoneRequest();
            loginPhoneRequest.MobilePhoneNumber = phoneNumber;
            loginPhoneRequest.Pin = pin;
            loginPhoneRequest.Language = "en";
            loginPhoneRequest.System = "QAPZNSVC01";
            loginPhoneRequest.Username = ConfigurationReader.Get("Environment:QA:PersonalizationRestSharpAutomation");

            // API Call
            IRestResponse response = restServices.postLoginPhone(loginPhoneRequest);
            var parsedResponse = JsonConvert.DeserializeObject<LoginResponse>(response.Content);

            // Assertions
            response.StatusCode.Should().Be(statusCode);
            parsedResponse.Errors[0].Description.Should().Be(errorDescription);
            Debug.WriteLine("*********************************************"+parsedResponse);
        }
      

        [Fact]
        public void validateCorrectLoginEmail()
        {
            Debug.WriteLine("****** Running test : Validate login with valid credentials ******");
            
            //Construct Login Email Request

            LoginEmailRequest loginEmailRequest= new LoginEmailRequest();
            loginEmailRequest.Email=ConfigurationReader.Get("Environment:QA:UserEmail");
            loginEmailRequest.Password=ConfigurationReader.Get("Environment:QA:UserPassword");
            loginEmailRequest.Language="en";
            loginEmailRequest.System= ConfigurationReader.Get("Environment:QA:System");
            loginEmailRequest.Username=ConfigurationReader.Get("Environment:QA:PersonalizationRestSharpAutomation");

            // API Call
            IRestResponse response = restServices.postLoginEmail(loginEmailRequest);
            var parsedResponse = JsonConvert.DeserializeObject<LoginResponse>(response.Content);

            // Assertions
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            parsedResponse.MobilePhoneNumber.Should().Be("9876543211");
            
        }

        [Theory]        
        [InlineData("Pzsqaint@gmail.com", "1235", HttpStatusCode.OK, "InvalidPassword")]
        [InlineData("1234557890@hotmail.com", "1235", HttpStatusCode.OK, "AccountDoesNotExist")]
        [InlineData("Pzsqaint@gmail.com", "", HttpStatusCode.BadRequest, "The POSTed request body failed validation.")]
        [InlineData("1234557890", "123", HttpStatusCode.BadRequest, "The POSTed request body failed validation.")]
        
        public void validateIncorrectLoginEmail(string email, string password, HttpStatusCode statusCode, string errorDescription)
        {
            Debug.WriteLine("****** Running test : Validate login with Invalid credentials ******");
            // Construct request from Request models
            LoginEmailRequest loginEmailRequest= new LoginEmailRequest();
            loginEmailRequest.Email=email;
            loginEmailRequest.Password=password;
            loginEmailRequest.Language="en";
            loginEmailRequest.System= ConfigurationReader.Get("Environment:QA:System");
            loginEmailRequest.Username=ConfigurationReader.Get("Environment:QA:PersonalizationRestSharpAutomation");

            // API Call
            IRestResponse response = restServices.postLoginEmail(loginEmailRequest);
            var parsedResponse = JsonConvert.DeserializeObject<LoginResponse>(response.Content);

            // Assertions
            response.StatusCode.Should().Be(statusCode);
            parsedResponse.Errors[0].Description.Should().Be(errorDescription);
            Debug.WriteLine("*********************************************"+parsedResponse);
        }
      
    }
}
