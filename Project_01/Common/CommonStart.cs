using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class CommonStart
    {
        public int Max_Time = int.MaxValue/10;
        public void Start()
        {
            Stopwatch sw = new Stopwatch();
            ABSChild child = new ABSChild();
            ABSBaseClass absBase = child;
            IChild iCInstance = new IChild();
            IBaseInterface iBInstance = iCInstance;
            sw.Restart();
            for (int i = 0; i < Max_Time; i++)
            {
                child.Do();
            }
            Console.WriteLine($"直接调用抽象类所用时间:{sw.ElapsedMilliseconds}");

            sw.Restart();
            for (int i = 0; i < Max_Time; i++)
            {
                absBase.Do();
            }
            Console.WriteLine($"直接调用抽象基类所用时间:{sw.ElapsedMilliseconds}");

            sw.Restart();
            for (int i = 0; i < Max_Time; i++)
            {
                iCInstance.Do();
            }
            Console.WriteLine($"直接调用接口实现类所用时间:{sw.ElapsedMilliseconds}");
            sw.Restart();
            for (int i = 0; i < Max_Time; i++)
            {
                iBInstance.Do();
            }
            Console.WriteLine($"直接调用接口基类所用时间:{sw.ElapsedMilliseconds}");
            Console.WriteLine();
        }

    }
}
