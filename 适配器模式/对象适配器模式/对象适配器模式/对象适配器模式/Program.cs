using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 对象适配器模式
{
    //目标接口
    interface Target
    {
         void request();
    }
    //适配者接口
    class Adaptee
    {
        public void specificRequest()
        {       
             Console.WriteLine("适配者中的业务代码被调用！");
         }
    }
    //对象适配器类
    class ObjectAdapter : Target
    {
        private Adaptee adaptee;
        public ObjectAdapter(Adaptee adaptee)
        {
            this.adaptee = adaptee;
        }
        public void request()
        {
            adaptee.specificRequest();
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("对象适配器测试");
            Adaptee adaptee = new Adaptee();
            Target target = new ObjectAdapter(adaptee);
            target.request();
            Console.ReadKey();
        }
    }
}
