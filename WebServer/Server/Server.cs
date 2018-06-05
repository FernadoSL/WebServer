using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using WebServer.Factories;
using WebServer.Helpers;

namespace WebServer.Server
{
    public class Server
    {
        private const string PingRequest = @"/";
        private const string ReadByKey = @"/Read/Key=";
        private const string ReadAllRequest = @"/ReadAll";

        private const string InsertRequest = @"/Insert";
        private const string UpdateAllRequest = @"/UpdateAll";

        private static DataAccess DataAccess { get; set; }

        private static HttpResponseFactory HttpResponseFactory = new HttpResponseFactory();
        
        public static Response ReceiveAndRespond(Request clientRequest)
        {
            string method = clientRequest.HttpMethod.ToUpper();
            string url = clientRequest.Url;

            if (method.Equals(HttpMethod.Get.Method))
            {
                return Get(url);
            }

            if (method.Equals(HttpMethod.Post.Method))
            {
                return Post(url);
            }

            if (method.Equals(HttpMethod.Put.Method))
            {
                return Put();
            }

            if (method.Equals(HttpMethod.Delete.Method))
            {
                return Delete();
            }

            return HttpResponseFactory.CreateNotFound();
        }

        private static Response Get(string url)
        {
            if(url.Equals(PingRequest))
            {
                return HttpResponseFactory.CreateOk("");
            }

            if (url.Contains(ReadByKey))
            {
                string key = url.Substring(url.IndexOf('=') + 1);
                string register = DataAccess.GetByKey(key);

                return HttpResponseFactory.CreateOk(register);
            }

            if (url.Equals(ReadAllRequest))
            {
                List<string> registerList = DataAccess.AllData;
                string result = string.Empty;
                registerList.ForEach(register => result = result + '\n' + register);

                return HttpResponseFactory.CreateOk(result);
            }

            return HttpResponseFactory.CreateNotFound();
        }

        private static Response Post(string url)
        {
            Response response = null;

            if (url.Equals(InsertRequest))
            {
                // inser novo registro.
            }

            if (url.Equals(UpdateAllRequest))
            {
                // atualiza todos os registros.
            }

            return response;
        }

        private static Response Put()
        {
            Response response = null;

            // atualiza um registro;

            return response;
        }

        private static Response Delete()
        {
            Response response = null;

            // deleta um registro.

            return response;
        }
    }
}