using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SinpleTestFramwork.Model
{
    public class MyData
    {
        public int A {  get; set; }
        public int B { get; set; }
        public int Result { get; set; }

        public MyData(int a, int b, int result)
        {
            A = a;
            B = b;
            Result = result;
        }

    }
}
