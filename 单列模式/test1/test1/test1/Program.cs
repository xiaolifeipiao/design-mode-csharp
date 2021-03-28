using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test1
{
    class Program
    {
        class President
        {
            private static volatile President instance = null; //保证instance在所有线程中同步
            //private避免类在外部被实例化
            private President()
            {
                Console.WriteLine("产生一个总统！");
            }
            private static object Sing_lock = new object();//锁同步
            public static President getInstance()
            {
                lock (Sing_lock)
                {
                    Console.WriteLine("路过");
                    if (instance == null)
                    {
                        Console.WriteLine("被创建");
                        instance = new President();
                    }
                    else
                    {
                        Console.WriteLine("已经有一个总统，不能产生新总统！");
                    }
                }
                return instance;
            }
            public void getName()
            {
                Console.WriteLine("我是美国总统：特朗普。");
            }
        }
        static void Main(string[] args)
        {
            President zt1 = President.getInstance();
            zt1.getName();    //输出总统的名字
            President zt2 = President.getInstance();
            zt2.getName();    //输出总统的名字
            if (zt1 == zt2)
            {
                Console.WriteLine("他们是同一人！");
            }
            else
            {
                Console.WriteLine("他们不是同一人！");
            }
            Console.ReadKey();
        }
    }
}
