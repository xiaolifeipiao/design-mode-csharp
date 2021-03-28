using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 外观模式
{
    class Facade
    {
        private SubSystem1 obj1 = new SubSystem1();
        private SubSystem2 obj2 = new SubSystem2();
        private SubSystem3 obj3 = new SubSystem3();
        public void method()
        {
            obj1.method1();
            obj2.method2();
            obj3.method3();
        }
    }
    //子系统角色1
    class SubSystem1
    {
        public void method1()
        {
            Console.WriteLine("子系统1被调用");
        }
    }
    //子系统角色2
    class SubSystem2
    {
        public void method2()
        {
            Console.WriteLine("子系统2被调用");
        }
    }
    //子系统角色3
    class SubSystem3
    {
        public void method3()
        {
            Console.WriteLine("子系统3被调用");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Facade f = new Facade();
            f.method();
            Console.ReadKey();
        }
    }
}
