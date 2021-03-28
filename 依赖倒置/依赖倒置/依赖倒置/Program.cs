using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 依赖倒置
{
    interface Shop
    {
         String sell();//卖
    }
    //韶关网店
    class ShaoguanShop : Shop
    {
        public String sell()
        {
            return "韶关土特产：香菇、木耳……";
        }
    }
    //婺源网店
    class WuyuanShop : Shop
    {
        public String sell()
        {
            return "婺源土特产：绿茶、酒糟鱼……";
        }
    }
    //顾客
    class Customer
    {
        public void shoping(Shop shop)
        {
            Console.WriteLine(shop.sell());
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Customer wang = new Customer();
            wang.shoping(new ShaoguanShop());
            wang.shoping(new WuyuanShop());
            Console.ReadKey();
        }
    }
}
