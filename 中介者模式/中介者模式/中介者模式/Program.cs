using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 中介者模式
{
    //抽象中介者
    abstract class Mediator
    {
        public abstract void register(Colleague colleague);
        public abstract void relay(Colleague c1);
    }
    //具体中介者
    class ConcreteMediator : Mediator
    {
        private List<Colleague> colleagues = new List<Colleague>();
        public override void register(Colleague colleague)
        {
            if (!colleagues.Contains(colleague))
            {
                colleagues.Add(colleague);
                colleague.setMedium(this);
            }
        }
        public override void relay(Colleague c1)
        {
            foreach (var i in colleagues)
            {
                if (i.Equals(c1))
                {
                    i.receive();
                }
            }
        }
    }
    //抽象同事类
    abstract class Colleague
    {
        protected Mediator mediator;
        public void setMedium(Mediator mediator)
        {
            this.mediator = mediator;
        }
        public abstract void receive();
        public abstract void send();
    }
    //具体同事类1
    class ConcreteColleague1 : Colleague
    {
        public override void receive()
        {
            Console.WriteLine("具体同事类1收到请求。");
        }
        public override void send()
        {
            Console.WriteLine("具体同事类1发出请求。");
            mediator.relay(this);//请求中介者转发
        }
    }
    //具体同事类2
    class ConcreteColleague2 : Colleague
    {
        public override void receive()
        {
            Console.WriteLine("具体同事类2收到请求。");
        }
        public override void send()
        {
            Console.WriteLine("具体同事类2发出请求。");
            mediator.relay(this);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Mediator md = new ConcreteMediator();
            Colleague c1, c2;
            c1 = new ConcreteColleague1();
            c2 = new ConcreteColleague2();
            md.register(c1);
            md.register(c2);
            c1.send();
            Console.WriteLine("----------------");
            c2.send();
            Console.ReadKey();
        }
    }
}
