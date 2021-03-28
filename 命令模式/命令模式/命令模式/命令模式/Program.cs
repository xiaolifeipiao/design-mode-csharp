using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 命令模式
{
    //调用者
    class Invoker
    {
        private Command command;
        public Invoker(Command command)
        {
            this.command = command;
        }
        public void setCommand(Command command)
        {
            this.command = command;
        }
        public void call()
       {
          Console.WriteLine("调用者执行命令command...");
          command.execute();
       }
    }
    //抽象命令
    abstract class Command
    {
        public abstract void execute();
    }
    //具体命令
    class ConcreteCommand : Command
    {
        private Receiver receiver;
        public ConcreteCommand()
        {
            receiver = new Receiver();
        }
        public override void execute()
        {
            receiver.action();
        }
    }
    //接收者
    class Receiver
    {
        public void action()
        {
            Console.WriteLine("接收者命令执行了");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Command cmd =new ConcreteCommand();
            Invoker ir = new Invoker(cmd);
            Console.WriteLine("客户访问调用者的call方法....");
            ir.call();
            Console.ReadKey();
        }
    }
}
