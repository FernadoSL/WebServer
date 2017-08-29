using System;

namespace WebServer.Server
{
    public class Request
    {
        public string AllText { get; private set; }

        public byte[] Bytes { get; private set; }

        public string Header { get; private set; }

        public string Body { get; private set; }

        public string[] HeaderSplited { get; private set; }

        public string HttpMethod { get { return this.HeaderSplited[0]; } }

        public string Url
        {
            get
            {
                if (this.HeaderSplited.Length > 1)
                    return this.HeaderSplited[1];
                else
                    return string.Empty;
            }
        }
        
        public Request()
        {
            this.Bytes = new byte[1024];
        }
        
        public void FormatRequest()
        {
            this.AllText = System.Text.Encoding.ASCII.GetString(this.Bytes, 0, this.Bytes.Length);
            this.HeaderSplited = this.AllText.Split(' ');
        }
    }
}
