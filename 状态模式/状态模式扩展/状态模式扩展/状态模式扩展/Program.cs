using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 状态模式扩展
{
    //环境类
    class ShareContext
    {
        private ShareState state;
        private Dictionary<string,ShareState> stateSet = new Dictionary<string,ShareState>();
        public ShareContext(){
            state= new ConcreteState1();
            stateSet.Add("1",state);
            state=new ConcreteState2();
            stateSet.Add("2",state);
            state=getState("1");
        }
        //设置新状态
        public void setState(ShareState state){
            this.state=state;
        }
        //读取状态
        public ShareState getState(string key){
            ShareState s;
            stateSet.TryGetValue(key,out s);
            return s;
        }
        //对请求做处理
        public  void Handle(){
            state.Handle(this);
        }
    }
    //抽象状态类
abstract class ShareState
{
    public abstract void Handle(ShareContext context);
}
    //具体状态1类
class ConcreteState1 : ShareState
{
    public override void Handle(ShareContext context)
    {
        Console.WriteLine("当前状态是： 状态1");
        context.setState(context.getState("2"));
    }
}
//具体状态2类
class ConcreteState2 : ShareState
{
    public override void Handle(ShareContext context)
    {
        Console.WriteLine("当前状态是： 状态2");
        context.setState(context.getState("1"));
    }
}
    class Program
    {
        static void Main(string[] args)
        {
            ShareContext c= new ShareContext();
            c.Handle();
            c.Handle();
            c.Handle();
            c.Handle();
            Console.ReadKey();
        }
    }
}
