using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 聚合模式
{
    //抽象聚合
    interface Aggregate
    {
         void add(Object obj);
         void remove(Object obj);
         Iterator getIterator();
    }
    //具体聚合
    class ConcreteAggregate : Aggregate
    {
        private List<Object> list = new List<object>();
        public new  void add(Object obj)
        {
            list.Add(obj);
        }
        public void remove(Object obj)
        {
            list.Add(obj);
        }
        public Iterator getIterator()
        {
            return (new ConcreteIterator(list));
        }
    }
    //抽象迭代器
    interface Iterator
    {
        Object first();
        Object next();
        Boolean hasNext();
    }
    //具体迭代器
    class ConcreteIterator : Iterator
    {
        private List<Object> list = null;
        private int index = -1;
        public ConcreteIterator(List<Object> list)
        {
            this.list = list;
        }
        public Boolean hasNext()
        {
            if (index < list.Count() - 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public Object first()
        {
            index = 0;
            Object obj = list.ElementAt(index);
            
            return obj;
        }
        public Object next()
        {
            Object obj = null;
            if (this.hasNext())
            {
                obj = list.ElementAt(++index);
            }
            return obj;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Aggregate ag=new ConcreteAggregate(); 
        ag.add("中山大学"); 
        ag.add("华南理工"); 
        ag.add("韶关学院");
        Console.WriteLine("聚合的内容有：");
        Iterator it=ag.getIterator(); 
        while(it.hasNext())
        { 
            Object ob=it.next(); 
            Console.Write(ob.ToString()+"\t"); 
        }
        Object obj=it.first();
        Console.WriteLine("\nFirst：" + obj.ToString());
         obj = it.next();
        Console.WriteLine("\nNext：" + obj.ToString());
         
        Console.ReadKey();
        }
    }
}
