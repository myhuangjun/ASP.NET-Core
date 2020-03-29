using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_01
{
    class Program
    {
        /// <summary>
        /// 测试formework效率
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            CommonStart start = new CommonStart();
            for (int i = 0; i < 10; i++)
            {
                start.Start();
            }
            Console.ReadKey();
        }
    }
}
