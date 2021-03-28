using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 原型模式实现1
{
    class citation : ICloneable
    {
        string name;
        string info;
        string college;
       public citation(string name, string info, string college)
        {
            this.name = name;
            this.info = info;
            this.college = college;
            Console.WriteLine("对象创建成功");
        }
       public void setName(String name)
        {
            this.name=name;
        }
         String getName()
        {
             return(this.name);
         }
      public  void display()
        {
             Console.WriteLine(name+info+college);
        }
        public Object Clone()
        {
            Console.WriteLine("奖状拷贝成功！");
            return (citation)this.MemberwiseClone();
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            citation obj1 = new citation("张三", "同学：在2016学年第一学期中表现优秀，被评为三好学生。", "韶关学院");
            obj1.display();
            citation obj2 = (citation)obj1.Clone();
            obj2.setName("李四");
            obj2.display();
            Console.ReadKey();
        }
    }
}
