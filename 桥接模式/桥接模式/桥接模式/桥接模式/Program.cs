using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 桥接模式
{
    class Program
    {
        //实现化角色
        interface Implementor
        {
            void OperationImpl();
        }
        //具体实现化角色
        class ConcreteImplementorA : Implementor
        {
            public void OperationImpl()
            {
                Console.WriteLine("具体化实现(Concrete Implementor)角色被访问");
            }
        }
        abstract class Abstraction
        {
            protected Implementor imple;
            protected Abstraction(Implementor imple)
            {
                this.imple = imple;
            }
            public abstract void Operation();
        }
        //扩展抽象化角色
        class RefinedAbstraction : Abstraction
        {
            public RefinedAbstraction(Implementor imple)
                : base(imple)
            {    
            }
            public override void Operation()
            {
                Console.WriteLine("扩展抽象化(Refined Abstraction)角色被访问");
                imple.OperationImpl();
            }
        }
        static void Main(string[] args)
        {
            Implementor imple = new ConcreteImplementorA();
            Abstraction abs = new RefinedAbstraction(imple);
            abs.Operation();
            Console.ReadKey();
        }
    }
}
