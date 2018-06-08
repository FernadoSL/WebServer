using System.Collections.Generic;
using System.Linq;

namespace WebServer.Web.Services
{
    public class DataAccess
    {
        private readonly string DataFilePath;

        public List<string> AllData { get; private set; }

        public DataAccess(string filePath)
        {
            this.DataFilePath = filePath;
            this.AllData = System.IO.File.ReadAllLines(this.DataFilePath).ToList();
        }

        public void Insert(string key, string value)
        {
            this.AllData.Add(string.Format("{0}:{1}", key, value));
        }

        public string GetByKey(string key)
        {
            var teste = this.AllData.FirstOrDefault(data => data.GetKey().Equals(key));
            return this.AllData.FirstOrDefault(data => data.GetKey().Equals(key));
        }

        public void Delete(string key)
        {
            this.AllData.RemoveAll(data => data.GetKey().Equals(key));
        }

        public void Update(string key, string value)
        {
            this.Delete(key);
            this.Insert(key, value);
        }

        public void SaveChanges()
        {
            System.IO.File.WriteAllLines(this.DataFilePath, this.AllData);
        }

        public void Truncate()
        {
            this.AllData = new List<string>();
        }
    }
}
