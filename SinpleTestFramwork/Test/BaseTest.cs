using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestApplication;

namespace SinpleTestFramwork.Test
{
    [TestClass]
    public class BaseTest
    {
        protected static SimpleCalculator app;
        //phai dat dung ten TestContext
        public TestContext TestContext {  get; set; }
        //de ke thua duoc bawt buoc phai dung InheritanceBehavior.BeforeEachDerivedClass
        [ClassInitialize(InheritanceBehavior.BeforeEachDerivedClass)]
        public static void SetUp(TestContext context)
        {
            app = new SimpleCalculator();

        }
    }
}
