using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 类模式
{
    //目标接口
    interface Target
    {
         void request();
    }
    //适配器接口
    class Adaptee
    {
        public void specificRequest()
        {
            Console.WriteLine("适配者中的业务代码被调用！");
        }
    }
    //类适配器
    class ClassAdapter : Adaptee, Target
    {
        public void request()
        {
            specificRequest();
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("类适配器模式调试：");
            Target target = new ClassAdapter();
            target.request();
            Console.ReadKey();
        }
    }
}
