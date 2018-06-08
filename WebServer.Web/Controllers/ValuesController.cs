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
        
        // POST api/values
        [HttpPost("/Insert")]
        public void Insert([FromBody]string value)
        {
            string key = (this.DataAccess.AllData.Count + 1).ToString();

            this.DataAccess.Insert(key, value);
            this.DataAccess.SaveChanges();
        }

        // PUT api/values/5
        [HttpPut("{key}")]
        public void Put(string key, [FromBody]string value)
        {
            this.DataAccess.Update(key, value);
            this.DataAccess.SaveChanges();
        }

        // DELETE api/values/5
        [HttpDelete("{key}")]
        public void Delete(string key)
        {
            this.DataAccess.Delete(key);
            this.DataAccess.SaveChanges();
        }
    }
}
