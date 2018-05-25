using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using WebServer.Helpers;

namespace WebServer.Test
{
    [TestClass]
    public class DataReaderTest
    {
        private DataAccess DataAccess { get; set; }

        [TestInitialize]
        public void Init()
        {
            this.DataAccess = new DataAccess(@"C:\Projetos\Outros\WebServer\data.txt");
        }

        [TestCleanup]
        public void Reset()
        {
            this.DataAccess.Truncate();
            this.DataAccess.SaveChanges();
        }

        [TestMethod]
        public void InsertTest()
        {
            string key = "1";
            string value = "torpedo";

            this.DataAccess.Insert(key, value);
            this.DataAccess.SaveChanges();

            var register = this.DataAccess.GetByKey(key);

            Assert.AreEqual(register.GetKey(), key);
            Assert.AreEqual(register.GetValue(), value);
        }

        [TestMethod]
        public void UpdateTest()
        {
            string key = "1";
            string value = "torpedo";

            this.DataAccess.Insert(key, value);
            this.DataAccess.SaveChanges();

            value = "dois torpedos";
            this.DataAccess.Update(key, value);
            this.DataAccess.SaveChanges();

            var register = this.DataAccess.GetByKey(key);

            Assert.AreEqual(register.GetKey(), key);
            Assert.AreEqual(register.GetValue(), value);
        }

        [TestMethod]
        public void DeleteTest()
        {
            string key = "1";
            string value = "torpedo";

            this.DataAccess.Insert(key, value);
            this.DataAccess.SaveChanges();

            this.DataAccess.Delete(key);
            this.DataAccess.SaveChanges();

            var register = this.DataAccess.GetByKey(key);

            Assert.IsNull(register);
            Assert.IsFalse(this.DataAccess.AllData.Any());
        }
    }
}
