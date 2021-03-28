using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 备忘录扩展
{
    //发起人原型
    class OrignatorPrototype : ICloneable
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
        public OrignatorPrototype createMemento()
        {
            return (OrignatorPrototype)this.Clone();
        }
        public void restoreMemento(OrignatorPrototype opt)
        {
            this.setState(opt.getState());
        }
        public object Clone()
        {
            try
            {
                return MemberwiseClone();
            }
            catch (Exception e)
            {
               
            }
            return null;
        }
    }
    //原型管理者
    class PrototypeCaretaker
    {
        private OrignatorPrototype opt;
        public void setMemento(OrignatorPrototype opt)
        {
            this.opt = opt;
        }
        public OrignatorPrototype getMemento()
        {
            return opt;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            OrignatorPrototype or = new OrignatorPrototype();
            PrototypeCaretaker cr = new PrototypeCaretaker();
            or.setState("S0");
            Console.WriteLine("初始状态:" + or.getState());
            cr.setMemento(or.createMemento());//保存状态
            or.setState("S1");
            Console.WriteLine("新的状态:" + or.getState());
            or.restoreMemento(cr.getMemento());//恢复状态
            Console.WriteLine("恢复状态:" + or.getState());
            Console.ReadKey();
        }
    }
}
