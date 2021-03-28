using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 访问者模式
{
    //抽象访问者
    interface Vistor
    {
        void visit(ConcreteElementA e);
        void visit(ConcreteElementB e);
    }
    //具体访问者
    class ConcreteVisitorA : Vistor
    {
        public void visit(ConcreteElementA e)
        {
            Console.WriteLine("具体访问者A访问--》" + e.operationA());
        }
        public void visit(ConcreteElementB element)
        {
            Console.WriteLine("具体访问者A访问-->" + element.operationB());
        }
    }
    //具体访问类B类
    class ConcreteVisitorB : Vistor
    {
        public void visit(ConcreteElementA e)
        {
            Console.WriteLine("具体访问者B访问--》" + e.operationA());
        }
        public void visit(ConcreteElementB element)
        {
            Console.WriteLine("具体访问者B访问-->" + element.operationB());
        }
    }
    //抽象元素类
    interface Element
    {
        void accept(Vistor vistor);
    }
    //具体元素类
    class ConcreteElementA : Element
    {
        public void accept(Vistor visitor)
        {
            visitor.visit(this);
        }
        public String operationA()
        {
            return "具体元素A的操作";
        }
    }
    //具体元素B的操作
    class ConcreteElementB : Element
    {
        public void accept(Vistor visitor)
        {
            visitor.visit(this);
        }
        public String operationB()
        {
            return "具体元素B的操作";
        }
    }
    //对象结构角色
    class ObjectStructure
    {
        private List<Element> list = new List<Element>();
        public void accept(Vistor vistor)
        {

            foreach (var item in list)
            {
                ((Element)item).accept(vistor);
            }
        }
        public void add(Element element)
        {
            list.Add(element);
        }
        public void remove(Element element)
        {
            list.Remove(element);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            ObjectStructure os = new ObjectStructure();
            os.add(new ConcreteElementA());
            os.add(new ConcreteElementB());
            Vistor visitor = new ConcreteVisitorA();
            os.accept(visitor);
            Console.WriteLine("------------------------");
            visitor = new ConcreteVisitorB();
            os.accept(visitor);
            Console.ReadKey();
        }
    }
}
