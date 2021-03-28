using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 责任链模式
{
    //抽象处理角色
    abstract class Handler
    {
        private Handler next;
        public void setNext(Handler next)
        {
            this.next = next;
        }
        public Handler getNext()
        {
            return next;
        }
        //处理请求方法
        public abstract void handleRequest(string request);
    }
    //具体处理者角色1
    class ConcreteHandler1 : Handler
    {
        public override void handleRequest(string request)
        {
            if (request.Equals("one"))
            {
                Console.WriteLine("具体处理者1负责处理该请求");
            }
            else
            {
                if (getNext() != null)
                {
                    getNext().handleRequest(request);
                }
                else
                {
                    Console.WriteLine("没有人处理请求");
                }
            }
        }
    }
    //具体处理者角色2
    class ConcreteHandler2 : Handler
    {
        public override void handleRequest(string request)
        {
            if (request.Equals("two"))
            {
                Console.WriteLine("具体处理者2负责处理该请求");
            }
            else
            {
                if (getNext() != null)
                {
                    getNext().handleRequest(request);
                }
                else
                {
                    Console.WriteLine("没得人处理该请求");
                }
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            //组装责任链
            Handler h1 = new ConcreteHandler1();
            Handler h2 = new ConcreteHandler2();
            h1.setNext(h2);
            //请求提交
            h1.handleRequest("two");
            Console.ReadKey();
        }
    }
}
