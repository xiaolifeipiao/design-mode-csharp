using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 装饰模式
{
    //抽象构建角色
   public abstract class Component
    {
       public abstract  void operation();
    }
    //具体构件角色
    class ConcreteComponent : Component
    {
        public ConcreteComponent()
        {
            Console.WriteLine("创建具体构件角色");
        }
        public override void operation()
        {
            Console.WriteLine("调用构件角色的方法operation");

        }
    }
    //抽象装饰角色
    class Decorator : Component
    {
        private Component component;
        public Decorator(Component component){
            this.component=component;
        }
        public override void operation()
        {
            component.operation();
        }
    }
    //具体装饰者角色
    class ConcreteDecorator : Decorator
    {
        public ConcreteDecorator( Component component):base(component){

        }
        public override void operation()
        {
            base.operation();
            addFunction();
        }
        public void addFunction()
        {
            Console.WriteLine("为具体构件角色增加额外的功能addFunction()");
        }

    }
    class Program
    {
        static void Main(string[] args)
        {
            Component p=new ConcreteComponent();
            p.operation();
            Console.WriteLine("---------------------------------");
            Component d=new ConcreteDecorator(p);
            d.operation();
            Console.ReadKey();
        }
    }
}
