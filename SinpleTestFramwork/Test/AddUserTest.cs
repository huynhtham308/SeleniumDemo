using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestApplication;

namespace SinpleTestFramwork.Test
{
    [TestClass]
    public class AddUserTest :BaseTest
    {

        [TestMethod("TC01: Add 2 User")]
        public void VerifyAdd2VilidValue()
        {
            //codeLens: support excutte test in this func(by right mouse=> run) and how many refferences
            var expectedvalue = app.Add("1", "3");

            Assert.AreEqual(expectedvalue, 4);
        }

    }
}
