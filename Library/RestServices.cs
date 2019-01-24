using System;
using System.Diagnostics;
using RestSharp;
using Utils;
using Models;
using Newtonsoft.Json;
using Microsoft.Extensions.Configuration;

namespace Library
{
    public class RestServices
    {
        public IRestResponse postLoginPhone(LoginPhoneRequest loginPhoneRequest)
        {
            // Endpoint setting from configuration
            var restClient = new RestClient(ConfigurationReader.Get("Environment:QA:Endpoint"));
            // Resource path setting from configuration
            var request = new RestRequest(ConfigurationReader.Get("Resources:Profiles:LoginPhone"), Method.POST);
            
            // Request format JSON/ XML
            request.RequestFormat = DataFormat.Json;
            request.AddJsonBody(loginPhoneRequest);
            
            // EXECUTE REQUEST
            IRestResponse response = executeRequest(restClient, request);
            return response;
        }

        public IRestResponse postLoginEmail(LoginEmailRequest loginEmailRequest)
        {
            // Endpoint setting from configuration
            var restClient = new RestClient(ConfigurationReader.Get("Environment:QA:Endpoint"));
            // Resource path setting from configuration
            var request = new RestRequest(ConfigurationReader.Get("Resources:Profiles:LoginEmail"), Method.POST);
            
            // Request format JSON/ XML
            request.RequestFormat = DataFormat.Json;
            request.AddJsonBody(loginEmailRequest);
            
            // EXECUTE REQUEST
            IRestResponse response = executeRequest(restClient, request);
            return response;
        }

        public IRestResponse executeRequest(RestClient restClient, RestRequest request)
        {
            IRestResponse response = null;
            var stopWatch = new Stopwatch();
            try
            {
                stopWatch.Start();
                response = restClient.Execute(request);
                stopWatch.Stop();
            }
            catch(Exception e)
            {
                Console.WriteLine("Exception : \n" +e.Message);
            }
            finally
            {
                // Logging raw request and response
                RestSharpHelper restSharpHelper = new RestSharpHelper();
                restSharpHelper.LogRequest(restClient, request, response, stopWatch.ElapsedMilliseconds);
            }
            return response;
        }

        public object parseJsonResponse(IRestResponse response)
        {
            return JsonConvert.DeserializeObject(response.Content);
        }
    }
}
