using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 扩展
{
    //目标接口
    interface TwoWayTarget
    {
        void request();
    }
    //适配器接口
    interface TwoWayAdaptee
    {
        void specificRequest();
    }
    //目标实现
    class TargetRealize : TwoWayTarget
    {
        public void request()
        {
            Console.WriteLine("目标代码被调用");
        }
    }
    //适配器实现
    class AdapteeRealize : TwoWayAdaptee
    {
        public void specificRequest()
        {
            Console.WriteLine("适配器代码被调用");
        }
    }
    //双向适配器
    class TwoWayAdapter : TwoWayAdaptee, TwoWayTarget
    {
        private TwoWayTarget target;
        private TwoWayAdaptee adaptee;
        public TwoWayAdapter(TwoWayTarget target)
        {
            this.target = target;
        }
        public TwoWayAdapter(TwoWayAdaptee adaptee)
        {
            this.adaptee = adaptee;
        }
        public void request()
        {
            adaptee.specificRequest();
        }
        public void specificRequest()
        {
            target.request();
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("目标同过双向适配器访问适配者");
            TwoWayAdaptee adaptee = new AdapteeRealize();
            TwoWayTarget target = new TwoWayAdapter(adaptee);
            target.request();
            Console.WriteLine("--------------------------");
            Console.WriteLine("适配者同过双向适配器访问适配者");
            target = new TargetRealize();
            adaptee = new TwoWayAdapter(target);
            adaptee.specificRequest();
            Console.ReadKey();

        }
    }
}
