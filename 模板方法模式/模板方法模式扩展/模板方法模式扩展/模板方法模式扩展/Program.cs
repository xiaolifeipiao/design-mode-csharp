using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 模板方法模式扩展
{
    //含钩子方法的抽象类
    abstract class HookAbstractClass
    {
        public void TemplateMethod()//模板方法
        {
            abstractMethod1();
            HookMethod1();
            if (HookMethod2())
            {
                SpecificMethod();
            }
            abstractMethod2();
        }

        public void SpecificMethod() //具体方法
        {
            Console.WriteLine("抽象类中的具体方法被调用...");
        }
        public virtual void HookMethod1() { }  //钩子方法1
        public virtual bool HookMethod2() //钩子方法2
        {
            return true;
        }
        public abstract void abstractMethod1(); //抽象方法1
        public abstract void abstractMethod2(); //抽象方法2
    }

    //含钩子方法的具体类
    class HookConcreteClass : HookAbstractClass
    {
        public override void abstractMethod1()
        {
            Console.WriteLine("抽象方法1的实现被调用");
        }
        public override void abstractMethod2()
        {
            Console.WriteLine("抽象方法2的实现被调用");
        }
        public override void HookMethod1()
        {
            Console.WriteLine("钩子方法1被重写...");
        }
        public override bool HookMethod2()
        {
            return false;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            HookAbstractClass tm = new HookConcreteClass();
            tm.TemplateMethod();
            Console.ReadKey();
        }
    }
}
