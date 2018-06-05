using WebServer.Server;

namespace WebServer.Factories
{
    public class HttpResponseFactory
    {
        private readonly string header = System.IO.File.ReadAllText(@"C:\Projetos\Outros\WebServer\header.txt");

        public Response CreateNotFound()
        {
            return new Response(header, "404", "Not Found", "");
        }

        public Response CreateOk(string data)
        {
            return new Response(header, "200", "Ok", data);
        }
            
    }
}
