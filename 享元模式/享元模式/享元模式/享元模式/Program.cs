using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 享元模式
{
    //非享元角色
    class UnsharedConcreteFlyweight
    {
        private string info;
        public UnsharedConcreteFlyweight(string info)
        {
            this.info = info;
        }
        public string getInfo()
        {
            return info;
        }
        public void setInfo(string info)
        {
            this.info = info;
        }
    }
    //抽象享元角色
    interface Flyweight{
      void  operation(UnsharedConcreteFlyweight state);
    }
    //具体享元角色
    class ConcreteFlyweight : Flyweight
    {
        private string key;
       public ConcreteFlyweight(string key)
        {
            this.key = key;
            Console.WriteLine("具体享元" + key + "被创建");
        }
        public void operation(UnsharedConcreteFlyweight outState)
        {
            Console.WriteLine("具体享元" + key + "被调用");
            Console.WriteLine("非享元信息是:" + outState.getInfo());
        }
    }
    //享元工厂角色
    class FlyweightFactory
    {
        private Dictionary<string, Flyweight> flyweight = new Dictionary<string, Flyweight>();
        public Flyweight getFlyweight(string key)
        {
            Flyweight flyweight1;
            flyweight.TryGetValue(key, out flyweight1);
            if (flyweight1 != null)
            {
                Console.WriteLine("具体享元" + key + "已存在，成功获取");
            }
            else
            {
                flyweight1 = new ConcreteFlyweight(key);
                flyweight.Add(key, flyweight1);
            }
            return flyweight1;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            FlyweightFactory factory = new FlyweightFactory();
            Flyweight f01 = factory.getFlyweight("a");
            Flyweight f02 = factory.getFlyweight("a");
            Flyweight f03 = factory.getFlyweight("a");
            Flyweight f04 = factory.getFlyweight("b");
            Flyweight f05 = factory.getFlyweight("b");
            f01.operation(new UnsharedConcreteFlyweight("第一次被调用a"));
            f02.operation(new UnsharedConcreteFlyweight("第二次被调用a"));
            f03.operation(new UnsharedConcreteFlyweight("第三次被调用a"));
            f04.operation(new UnsharedConcreteFlyweight("第一次调用b"));
            f05.operation(new UnsharedConcreteFlyweight("第二次调用b"));
            Console.ReadKey();

        }
    }
}
