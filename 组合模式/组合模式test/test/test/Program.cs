using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test
{
    //抽象构件：物品
    interface Articles
    {
        float calculation();//计算
        void show();
    }
    //树叶构件：商品
    class Goods:Articles{
        private string name;//名字
        private int quantity;//数量
        private float unitPrice;//单价
        public Goods(string name, int quantity, float unitPrice)
        {
            this.name = name;
            this.quantity = quantity;
            this.unitPrice = unitPrice;

        }
        public float calculation()
        {
            return quantity * unitPrice;
        }
        public void show()
        {
            Console.WriteLine(name + "[数量：" + quantity + ",单价：" + unitPrice + "元]");
        }
    }
    //树枝构件：袋子
    class Bags:Articles{
        private string name;//名字
        private List<Articles> bags = new List<Articles>();
        public Bags(string name)
        {
            this.name = name;
        }
        public void add(Articles c)
        {
            bags.Add(c);
        }
        public void remove(Articles c)
        {
            bags.Remove(c);
        }
        public Articles getChild(int i)
        {
            return bags.ElementAt(i);
        }
        public float calculation()
        {
            float s = 0;
            foreach (var i in bags)
            {
                s += i.calculation();
            }
            return s;
        }
        public void show()
        {
            foreach (var i in bags)
            {
                i.show();
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            float s=0;
        Bags BigBag,mediumBag,smallRedBag,smallWhiteBag;
        Goods sp;
        BigBag=new Bags("大袋子");
        mediumBag=new Bags("中袋子");
        smallRedBag=new Bags("红色小袋子");
        smallWhiteBag=new Bags("白色小袋子");               
        sp=new Goods("婺源特产",2,7.9f);
        smallRedBag.add(sp);
        sp=new Goods("婺源地图",1,9.9f);
        smallRedBag.add(sp);       
        sp=new Goods("韶关香菇",2,68);
        smallWhiteBag.add(sp);
        sp=new Goods("韶关红茶",3,180);
        smallWhiteBag.add(sp);       
        sp=new Goods("景德镇瓷器",1,380);
        mediumBag.add(sp);
        mediumBag.add(smallRedBag);       
        sp=new Goods("李宁牌运动鞋",1,198);
        BigBag.add(sp);
        BigBag.add(smallWhiteBag);
        BigBag.add(mediumBag);
        //BigBag.remove(smallRedBag);
        Console.WriteLine("您选购的商品有：");
        smallRedBag.show();
        s = smallRedBag.calculation();
        Console.WriteLine("要支付的总价是：" + s + "元");
        BigBag.show();
        s=BigBag.calculation();
        Console.WriteLine("要支付的总价是：" + s + "元");
        Console.ReadKey();
        }
    }
}
