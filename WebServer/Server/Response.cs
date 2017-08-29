using System;

namespace WebServer.Server
{
    public class Response
    {
        public string AllText { get; private set; }

        public byte[] Bytes { get; private set; }

        public string Header { get; private set; }

        public string Body { get; private set; }

        public string[] HeaderSplited { get; private set; }

        public string StatusCode { get { return this.HeaderSplited[1]; } }

        public string Status { get { return this.HeaderSplited[2]; } }

        public Response(string header, string statusCode, string status, string body)
        {
            this.Bytes = new byte[1024];
            this.HeaderSplited = header.Split(' ');
            this.HeaderSplited[1] = statusCode;
            this.HeaderSplited[2] = status;
            this.Header = String.Join(" ", this.HeaderSplited);
            this.AllText = this.Header + body;
        }

        public void FormatResponse()
        {
            this.Bytes = System.Text.Encoding.ASCII.GetBytes(this.AllText);
        }
    }
}
