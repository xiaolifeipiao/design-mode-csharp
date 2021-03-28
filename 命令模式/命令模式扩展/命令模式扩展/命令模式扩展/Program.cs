using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 命令模式扩展
{
    //抽象命令
    abstract class AbstrectCommand
    {
        public abstract void execute();
    }
    //树叶构件:具体命令1
    class ConcreteCommand1 : AbstrectCommand
    {
        private CompositeReceiver receiver;
        public ConcreteCommand1()
        {
            receiver = new CompositeReceiver();
        }
        public override void execute()
        {
            receiver.action1();
        }
    }
    //树叶构件: 具体命令2
    class ConcreteCommand2 : AbstrectCommand
    {
        private CompositeReceiver receiver;
        public ConcreteCommand2()
        {
            receiver = new CompositeReceiver();
        }
        public override void execute()
        {
            receiver.action2();
        }
    }
    //树枝构件：调用者
    class CompositeInvoker : AbstrectCommand
    {
        private List<AbstrectCommand> list = new List<AbstrectCommand>();
        public void add(AbstrectCommand c)
        {
            list.Add(c);
        }
        public void remove(AbstrectCommand c)
        {
            list.Remove(c);
        }
        public AbstrectCommand getChild(int i)
        {
            return list.ElementAt(i);
        }
        public override void execute()
        {
            foreach (var i in list)
            {
                i.execute();
            }
        }
    }
    //接收者
    class CompositeReceiver
    {
        public void action1()
        {
            Console.WriteLine("接收者的action1()方法被调用...");
        }
        public void action2()
        {
            Console.WriteLine("接收者的action2()方法被调用...");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            AbstrectCommand cmd1 = new ConcreteCommand1();
            AbstrectCommand cmd2 = new ConcreteCommand2();
            CompositeInvoker ir = new CompositeInvoker();
            ir.add(cmd1);
            ir.add(cmd2);
            Console.WriteLine("客户访问调用者的execute()方法...");
            ir.execute();
            Console.ReadKey();
        }
    }
}
