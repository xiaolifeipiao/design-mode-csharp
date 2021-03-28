using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 策略模式
{
    //抽象策略类
    interface Strategy
    {
         void strategyMethod(); //策略方法
    }
    //具体策略类a
    class ConcreteStrategyA : Strategy
    {
        public void strategyMethod()
        {
            Console.WriteLine("具体策略A的策略方法被访问");
        }
    }
    //具体策略类B
    class ConcreteStrategyB : Strategy
    {
        public void strategyMethod()
        {
            Console.WriteLine("具体策略B的策略方法被访问");
        }
    }
    //环境类
    class Context
    {
        private Strategy strategy;
        public Strategy getStrategy()
        {
            return strategy;
        }
        public void setStrategy(Strategy strategy)
        {
            this.strategy = strategy;
        }
        public void strategyMethod()
        {
            strategy.strategyMethod();
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Context c = new Context();
            Strategy s = new ConcreteStrategyA();
            c.setStrategy(s);
            c.strategyMethod();
            Console.WriteLine("---------------");
            s = new ConcreteStrategyB();
            c.setStrategy(s);
            c.strategyMethod();
            Console.ReadKey();
        }
    }
}
