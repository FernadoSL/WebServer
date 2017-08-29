using System;
using System.IO;
using System.Net;
using WebServer.Helpers;
using static System.Net.WebRequestMethods;

namespace WebServer.Server
{
    public static class Server
    {
        // Locais das views e templates
        private const string IndexRequest = @"/";
        private const string RootLocal = @"C:..\..\Views";
        private const string HeaderTemplateLocal = @"C:..\..\..\headerTemplate.txt";
        private const string NotFoundViewLocal = @"C:..\..\Views\notFoundView.html";

        public static Response ReceiveAndRespond(Request clientRequest)
        {
            Response response = null;
            string method = clientRequest.HttpMethod.ToUpper();
            string url = clientRequest.Url;

            if (!string.IsNullOrEmpty(method) && !string.IsNullOrEmpty(url) && method.Equals(Http.Get))
            {
                string viewLocal;

                if (url.Equals(IndexRequest))
                {
                    viewLocal = RootLocal + "\\index.html";
                }
                else
                {
                    viewLocal = RootLocal + url.Replace("/", "\\");
                }

                response = CreateResponse(viewLocal);
            }
            else if (!string.IsNullOrEmpty(method) && method.Equals(Http.Post))
            {
            }
            else
            {
                response = null;
            }

            return response;
        }

        private static Response CreateResponse(string viewLocal)
        {
            string header = FileReader.Read(HeaderTemplateLocal);
            string body = string.Empty;
            int responseCode = (int)HttpStatusCode.OK;
            string responseStatus = HttpStatusCode.OK.ToString();

            try
            {
                body = FileReader.Read(viewLocal);
            }
            catch (FileNotFoundException)
            {
                body = FileReader.Read(NotFoundViewLocal);
                responseCode = (int)HttpStatusCode.NotFound;
                responseStatus = HttpStatusCode.NotFound.ToString();
            }
            catch (Exception)
            {
                // implementar retorno de erro no servidor
            }

            Response result = new Response(header, responseCode.ToString(), responseStatus, body);
            result.FormatResponse();

            return result;
        }
    }
}