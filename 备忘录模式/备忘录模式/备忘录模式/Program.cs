using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 备忘录模式
{
    //备忘录
    class Memento
    {
        private String state;
        public Memento(String state)
        {
            this.state = state;
        }
        public void setState(String state)
        {
            this.state = state;
        }
        public String getState()
        {
            return state;
        }
    }
    //发起人
    class Originator
    {
        private String state;
        public void setState(String state)
        {
            this.state = state;
        }
        public String getState()
        {
            return state;
        }
        public Memento createMement()
        {
            return new Memento(state);
        }
        public void restoreMemento(Memento m)
        {
            this.setState(m.getState());
        }
    }
    //管理者
    class Caretaker
    {
        private Memento memento;
        public void setMemento(Memento m)
        {
            memento = m;
        }
        public Memento getMemento()
        {
            return memento;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Originator or = new Originator();
            Caretaker cr = new Caretaker();
            or.setState("S0");
            Console.WriteLine("初始状态:" + or.getState());
            cr.setMemento(or.createMement());
            or.setState("S1");
            Console.WriteLine("新的状态:" + or.getState());
            or.restoreMemento(cr.getMemento());//恢复
            Console.WriteLine("恢复状态:" + or.getState());
            Console.ReadKey();
        }
    }
}
