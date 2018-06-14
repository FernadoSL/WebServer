using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using WebServer.Web.Services;

namespace WebServer.Web.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        private DataAccess DataAccess { get; set; }

        public ValuesController()
        {
            this.DataAccess = new DataAccess(@"C:\Projetos\Outros\WebServer\data.txt");
        }

        [HttpGet("/HealthCheck")]
        public string HealthCheck()
        {
            return "success";
        }

        [HttpGet("/ReadAll")]
        public IEnumerable<string> ReadAll()
        {
            return this.DataAccess.AllData;
        }

        [HttpGet("{key}")]
        public string GetByKey(string key)
        {
            return this.DataAccess.GetByKey(key);
        }


        [HttpPost("/Insert")]
        public void Insert([FromBody]string data)
        {
            this.DataAccess.Insert(data.GetKey(), data.GetValue());
            this.DataAccess.SaveChanges();
        }

        [HttpPut("{key}")]
        public void Put(string key, [FromBody]string value)
        {
            this.DataAccess.Update(key, value);
            this.DataAccess.SaveChanges();
        }

        [HttpDelete("{key}")]
        public void Delete(string key)
        {
            this.DataAccess.Delete(key);
            this.DataAccess.SaveChanges();
        }

        [HttpPost("UpdateAll")]
        public void UpdateAll([FromBody]List<string> allData)
        {
            this.DataAccess.Truncate();
            this.DataAccess.SaveChanges();

            foreach (var data in allData)
            {
                this.DataAccess.Insert(data.GetKey(), data.GetValue());
            }

            this.DataAccess.SaveChanges();
        }
    }
}
