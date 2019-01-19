using RestSharp;
using System;
using Newtonsoft.Json;
using System.Linq;
using System.Diagnostics;

namespace Utils
{
    public class RestSharpHelper
    {
        public T Execute<T>(RestRequest request, RestClient client) where T : new()
        {
            var response = client.Execute<T>(request);
            if (response.ErrorException != null)
            {
                const string message = "Error retrieving response.  Check exception details for more info.";
                var exception = new ApplicationException(message, response.ErrorException);
                throw exception;
            }
            return response.Data;
        }

        public void LogRequest(RestClient restClient, IRestRequest request, IRestResponse response, long durationMs)
        {
            
            var requestToLog = new
            {
                resource = request.Resource,
                parameters = request.Parameters.Select(parameter => new
                {
                    name = parameter.Name,
                    value = parameter.Value,
                    type = parameter.Type.ToString()
                }),
                method = request.Method.ToString(),
                uri = restClient.BuildUri(request),
            };

            var responseToLog = new
            {
                statusCode = response.StatusCode,
                content = response.Content,
                headers = response.Headers,
                responseUri = response.ResponseUri,
                errorMessage = response.ErrorMessage,
            };

            Debug.Write(string.Format("Request completed in {0} ms, \nRequest:\n{1}, \nResponse:\n {2}\n",
                    durationMs, 
                    JsonConvert.SerializeObject(requestToLog),
                    JsonConvert.SerializeObject(responseToLog)));
        }
    }
}