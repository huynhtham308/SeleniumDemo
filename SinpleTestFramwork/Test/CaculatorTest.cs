using SinpleTestFramwork.Model;
using System.Diagnostics;
using System.Reflection.Metadata.Ecma335;
using TestApplication;

namespace SinpleTestFramwork.Test
{
    [TestClass]//atribute
    public class CaculatorTest : BaseTest
    {
        /// <summary>
        /// TC01: Add 2 valid value 2"
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="expectedResult"></param>
        //[DataRow(1, 2, 3)]
        [DataTestMethod]
        [DynamicData(nameof(MyDataCreator), DynamicDataSourceType.Method)]
        public void VerifyAdd2VilidValue(MyData m)
        {
            ////codeLens: support excutte test in this func(by right mouse=> run) and how many refferences
            var actual = app.Add(m.A.ToString(), m.B.ToString());

            Assert.AreEqual(m.Result.ToString(), actual.ToString());
        }


        public static IEnumerable<object[]> MyDataCreator()
        {
            return new List<object[]>()
    {
        new object[] { new MyData(1, 1, 2) },
        new object[]{new MyData(1,3,4)},
        new object[]{new MyData(4,5,9)}
    };
        }

        //[TestMethod("TC01: Add 2 valid value 2")]
        //public void VerifyAdd2VilidValue2()
        //{
        //    //codeLens: support excutte test in this func(by right mouse=> run) and how many refferences
        //    var actual = app.Add("1", "3");

        //    Assert.AreEqual(4, actual);
        //}

        //[TestMethod("TC02: Add 2 invalid value")]
        ////[ExpectedException (typeof(InvalidOperationException))/*]*/
        //public void VerifyAdd2InvalidValue()
        //{
        //    //cach 1: try catch
        //    //try
        //    //{
        //    //    app.Add("ffff", "-3");
        //    //}
        //    //catch (InvalidDataException ex) { }
        //    //catch
        //    //{
        //    //    Assert.Fail();
        //    //}
        //    //cach 2 sd anonation:  [ExpectedException (typeof(InvalidOperationException))]: dung khi co 1 assert 
        //    //cach 3: dung khi co nhieu assert in method
        //    Assert.ThrowsException<InvalidDataException>(() => app.Add("ffff", "-3"));
        //}

        //[TestMethod("TC03: Add 2 big value")]
        //[Timeout(1000)]//ms=>1s
        //public void VerifyTimeout()
        //{
        //    var actual = app.Add("2000000", "3000000");

        //    Assert.AreEqual(5000000, actual);
        //}
    }
}
