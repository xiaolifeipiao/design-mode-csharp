using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 中介者模式扩展
{
    //简单单列中介者
    class SimpleMediator
    {
        private static SimpleMediator smd = new SimpleMediator();
        private List<SimpleColleague> colleagues = new List<SimpleColleague>();
        private SimpleMediator() { }
        public static SimpleMediator getMedium()
        {
            return smd;
        }
        public void register(SimpleColleague colleague)
        {
            if (!colleagues.Contains(colleague))
            {
                colleagues.Add(colleague);
            }
        }
        public void relay(SimpleColleague sc1)
        {
            foreach (var i in colleagues)
            {
                if (i.Equals(sc1))
                {
                    i.receive();
                }
            }
        }
    }
    //抽象同事类
    interface SimpleColleague
    {
        void receive();
        void send();
    }
    //具体同事类
    class SimpleConcreColleague1 : SimpleColleague
    {
       public SimpleConcreColleague1()
        {
            SimpleMediator smd = SimpleMediator.getMedium();
            smd.register(this);
        }
        public new void receive()
        {
            Console.WriteLine("具体同事类1：收到请求。");

        }
        public new void send()
        {
            SimpleMediator smd = SimpleMediator.getMedium();
            Console.WriteLine("具体同事类1：发出请求。。");
            smd.relay(this);//请求中介者转发
        }
    }
    //具体同事类2
class SimpleConcreteColleague2 : SimpleColleague
{
    public SimpleConcreteColleague2(){
        SimpleMediator smd=SimpleMediator.getMedium();
        smd.register(this);
    }
    public void receive()
    {    Console.WriteLine("具体同事类2：收到请求。");    }   
    public void send()
    {
        SimpleMediator smd=SimpleMediator.getMedium();
        Console.WriteLine("具体同事类2：发出请求...");
        smd.relay(this); //请中介者转发
    }
}
    class Program
    {
        static void Main(string[] args)
        {
            SimpleColleague c1,c2;
            c1 = new SimpleConcreColleague1();
            c2=new SimpleConcreteColleague2();
            c1.send();
            Console.WriteLine("-----------------");
            c2.send();
            Console.ReadKey();
        }
    }
}
