using System;
using System.IO;
using System.Net;
using System.Net.Http;
using WebServer.Helpers;
using static System.Net.WebRequestMethods;

namespace WebServer.Server
{
    public static class Server
    {
        private const string ReadByKey = @"/Read/Key=";
        private const string ReadAllRequest = @"/ReadAll";

        private const string InsertRequest = @"/Insert";
        private const string UpdateAllRequest = @"/UpdateAll";



        public static Response ReceiveAndRespond(Request clientRequest)
        {
            string method = clientRequest.HttpMethod.ToUpper();
            string url = clientRequest.Url;

            if (method.Equals(HttpMethod.Get))
            {
                return Get(url);
            }

            if (method.Equals(HttpMethod.Post))
            {
                return Post(url);
            }

            if (method.Equals(HttpMethod.Put))
            {
                return Put();
            }

            if (method.Equals(HttpMethod.Delete))
            {
                return Delete();
            }

            return new Response("", "404", "Not Found", "");
        }

        private static Response Get(string url)
        {
            Response response = null;

            if (url.Contains(ReadByKey))
            {
                // ler um registro buscado por chave.
            }

            if (url.Equals(ReadAllRequest))
            {
                // ler todos registros.
            }

            return response;
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

        private static Response CreateResponse()
        {
            Response result = null;
            
            return result;
        }
    }
}