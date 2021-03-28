using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace 组合模式
{
    //抽象构件
    interface Component
    {
        void add(Component c);
        void remove(Component c);
        Component getChild(int i);
        void operation();
    }
    //树叶构件
    class Leaf : Component
    {
        private string name;
        public Leaf(string name)
        {
            this.name = name;
        }
        public void add(Component c)
        {

        }
        public void remove(Component c)
        {

        }
        public Component getChild(int i)
        {
            return null;
        }
        public void operation()
        {
            Console.WriteLine("树叶" + name + ":被访问");
        }
    }
    //树枝构件
    class Composite : Component
    {
        private List<Component> list = new List<Component>();
        public void add(Component c) {
            list.Add(c);
        }
        public void remove(Component c){
            list.Remove(c);
        }
        public Component getChild(int i)
        {
            return list.ElementAt(i);
        }
        public void operation()
        {
            foreach(var i in list){
                ((Component)i).operation();
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Component c0 = new Composite();
            Component c1 = new Composite();
            Component left1 = new Leaf("1");
            Component left2 = new Leaf("2");
            Component left3 = new Leaf("3");
            c0.add(left1);
            c0.add(c1);
            c1.add(left2);
            c1.add(left3);
            c0.operation();
            Console.ReadKey();

        }
    }
}
