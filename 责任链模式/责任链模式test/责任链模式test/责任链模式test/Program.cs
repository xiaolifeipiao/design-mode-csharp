using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 责任链模式test
{
    //抽象处理类：领导类
    abstract class Leader
    {
        private Leader next;
        public void setNext(Leader next)
        {
            this.next = next;
        }
        public Leader getNext()
        {
            return next;
        }
        //具体请求方法
        public abstract void handleRequest(int LeaveDay);
    }
    //具体处理类1：班主任类
    class ClassAdviser : Leader
    {
        public override void handleRequest(int LeaveDays)
        {
            if (LeaveDays < 2)
            {
                Console.WriteLine("班主任批准你请假" + LeaveDays + "天");
            }
            else
            {
                if (getNext() != null)
                {
                    getNext().handleRequest(LeaveDays);
                }
                else
                {
                    Console.WriteLine("请假天数太多，没得人批准改假条");
                }
            }

        }
    }
    //具体处理者2：系主任类
    class DepartmentHead : Leader
    {
        public override void handleRequest(int LeaveDays)
        {
            if (LeaveDays <= 7)
            {
                Console.WriteLine("系主任批准您请假" + LeaveDays + "天。");
            }
            else
            {
                if (getNext() != null)
                {
                    getNext().handleRequest(LeaveDays);
                }
                else
                {
                    Console.WriteLine("请假天数太多，没有人批准该假条！");
                }
            }
        }
    }
    //具体处理者3：院长类
    class Dean : Leader
    {
        public override void handleRequest(int LeaveDays)
        {
            if (LeaveDays <= 10)
            {
                Console.WriteLine("院长批准您请假" + LeaveDays + "天。");
            }
            else
            {
                if (getNext() != null)
                {
                    getNext().handleRequest(LeaveDays);
                }
                else
                {
                    Console.WriteLine("请假天数太多，没有人批准该假条！");
                }
            }
        }
    }
    //具体处理者4：教务处长类
    class DeanOfStudies : Leader
    {
        public override void handleRequest(int LeaveDays)
        {
            if (LeaveDays <= 20)
            {
                Console.WriteLine("教务处长批准您请假" + LeaveDays + "天。");
            }
            else
            {
                if (getNext() != null)
                {
                    getNext().handleRequest(LeaveDays);
                }
                else
                {
                    Console.WriteLine("请假天数太多，没有人批准该假条！");
                }
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Leader t1 = new ClassAdviser();
            Leader t2 = new DepartmentHead();
            Leader t3 = new Dean();
            Leader t4 = new DeanOfStudies();
            t1.setNext(t2);
            t2.setNext(t3);
            t3.setNext(t4);
            t1.handleRequest(8);
            Console.ReadKey();
        }
    }
}
