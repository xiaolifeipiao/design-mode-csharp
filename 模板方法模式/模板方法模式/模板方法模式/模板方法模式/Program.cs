using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 模板方法模式
{
    //抽象类
    abstract class AbstractClass
    {
        public void TemplateMethod()//模板方法
        {
            SpecificMethod();
            abstractMethod1();
            abstractMethod2();
        }
        public void SpecificMethod()
        {
            Console.WriteLine("抽象类中的具体方法被调用...");
        }
        public abstract void abstractMethod1(); //抽象方法1
        public abstract void abstractMethod2(); //抽象方法2
    }
    //具体子类
    class ConcreteClass : AbstractClass {
        public override void abstractMethod1()
        {
            Console.WriteLine("抽象方法1的实现被调用...");
        }
        public override void abstractMethod2()
        {
            Console.WriteLine("抽象方法2的实现被调用...");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            AbstractClass a = new ConcreteClass();
            a.TemplateMethod();
            Console.ReadKey();
        }
    }
}
