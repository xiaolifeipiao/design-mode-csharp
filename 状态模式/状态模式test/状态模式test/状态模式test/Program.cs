using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 状态模式test
{
    //环境类
    class ScoreContext
    {
        private AbstractState state;
       public ScoreContext()
        {
            state = new LowState(this);
        }
        public void setState(AbstractState state)
        {
            this.state = state;
        }
        public AbstractState getState()
        {
            return state;
        }
        public void add(int score)
        {
            state.addScore(score);
        }
    }
    //抽象状态类
    abstract class AbstractState
    {
        public ScoreContext hj;//环境
        protected string stateName;//状态名
        public int scoce;//分数
        public abstract void checkState();//检查当前状态
        public void addScore(int x)
        {
            scoce += x;
            Console.Write("加上" + x + "分，当前分数：" + scoce);
            checkState();
            Console.WriteLine("分，当前状态：" + hj.getState().stateName);
        }

    }
    //具体状态类：不及格
    class LowState : AbstractState
    {
        public LowState(ScoreContext h)
        {
            hj = h;
            stateName = "不及格";
            scoce = 0;
        }
        public LowState(AbstractState state)
        {
            hj = state.hj;
            stateName = "不及格";
            scoce = state.scoce;
        }
        public override void checkState()
        {
            if (scoce >= 90)
            {
                hj.setState(new HighState(this));
            }
            else if (scoce < 60)
            {
                hj.setState(new MiddleState(this));
            }
        }
    }
    //具体状态类：中等
    class MiddleState : AbstractState
    {
        public MiddleState(AbstractState state)
        {
            hj = state.hj;
            stateName = "中等";
            scoce = state.scoce;
        }
        public override void checkState()
        {
            if (scoce < 60)
            {
                hj.setState(new LowState(this));
            }
            else if (scoce >= 90)
            {
                hj.setState(new HighState(this));
            }
        }
    }
    //具体状态类：优秀
    class HighState : AbstractState
    {
        public HighState(AbstractState state)
        {
            hj = state.hj;
            stateName = "优秀";
            scoce = state.scoce;
        }
        public override void checkState()
        {
            if (scoce < 60)
            {
                hj.setState(new LowState(this));
            }
            else if (scoce < 90)
            {
                hj.setState(new MiddleState(this));
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            ScoreContext account=new ScoreContext();
        Console.WriteLine("学生成绩状态测试：");
        account.add(30);
        account.add(40);
        account.add(25);
        account.add(-15);
        account.add(-25);
        Console.ReadKey();
        }
    }
}
