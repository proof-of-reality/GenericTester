using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using Tester;
using Xunit;

namespace ApiTester
{
    public class ApiTester
    {
        [Fact]
        public void Test()
        {
            object previous;
            using (StreamReader r = new StreamReader(@"D:\file.json"))
            {
                previous = r.ReadToEnd();
            }
            var result = JsonConvert.SerializeObject(Tester.Tester.Test());
            Assert.Equal(previous, result);
        }
    }
}
