using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 接口隔离
{
    //输入模块
    interface InputModule
    {
        void insert();
        void delete();
        void modify();
    }
    //统计模块接口
    interface CountModule
    {
        void countTotalScore();
        void countAverage();
    }
    //打印模块接口
    interface PrintModule
    {
        void printStuInfo();
        void queryStuInfo();

    }
    //实现类
    class StuScoreList : InputModule, CountModule, PrintModule
    {
        private StuScoreList() { }
        public static InputModule getInputModule()
        {
            return (InputModule)new StuScoreList();
        }
        public static CountModule getCountModule()
        {
            return (CountModule)new StuScoreList();
        }
        public static PrintModule getPrintModule()
        {
            return (PrintModule)new StuScoreList();
        }

        public void insert()
    {
        Console.WriteLine("输入模块的insert()方法被调用！");
    }
        public void delete()
    {
        Console.WriteLine("输入模块的delete()方法被调用！");
    }
        public void modify()
    {
        Console.WriteLine("输入模块的modify()方法被调用！");
    }
        public void countTotalScore()
    {
        Console.WriteLine("统计模块的countTotalScore()方法被调用！");
    }
        public void countAverage()
    {
        Console.WriteLine("统计模块的countAverage()方法被调用！");
    }
        public void printStuInfo()
    {
        Console.WriteLine("打印模块的printStuInfo()方法被调用！");
    }
        public void queryStuInfo()
    {
        Console.WriteLine("打印模块的queryStuInfo()方法被调用！");
    }

    }
    class Program
    {
        static void Main(string[] args)
        {
            InputModule input = StuScoreList.getInputModule();
            CountModule count = StuScoreList.getCountModule();
            PrintModule print = StuScoreList.getPrintModule();
            input.insert();
            count.countTotalScore();
            print.printStuInfo();
            Console.ReadKey();
        }
    }
}
