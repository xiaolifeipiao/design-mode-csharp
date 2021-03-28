using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace abstractProduct
{
    /// <summary>  
    /// 水果抽象工厂  
    /// </summary>  
    public abstract class FruitAbstractFactory
    {
        /// <summary>  
        /// 水果名称，表示哪种水果如：苹果、香蕉、橘子  
        /// </summary>  
        public string FruitName { get; set; }
        /// <summary>  
        /// 抽象方法，获取要批发水果的  
        /// </summary>  
        /// <returns>要批发的水果</returns>  
        public abstract string GetCurrentFruit();
    }
    /// <summary>  
    /// 苹果工厂  
    /// </summary>  
    public class AppleFactory : FruitAbstractFactory
    {
        public AppleFactory()
        {
            FruitName = "苹果";
        }
        /// <summary>  
        /// 重写基类的获取水果方法  
        /// </summary>  
        /// <returns>要批发的水果</returns>  
        public override string GetCurrentFruit()
        {
            return "给你:" + base.FruitName;
        }
    }
    /// <summary>  
    /// 香蕉工厂  
    /// </summary>  
    public class BananaFactory : FruitAbstractFactory
    {
        public BananaFactory()
        {
            FruitName = "香蕉";
        }

        public override string GetCurrentFruit()
        {
            return "给你:" + base.FruitName;
        }
    }
    /// <summary>  
    /// 橘子工厂  
    /// </summary>  
    public class TangerineFactory : FruitAbstractFactory
    {
        public TangerineFactory()
        {
            FruitName = "橘子";
        }
        public override string GetCurrentFruit()
        {
            return "给你:" + base.FruitName;
        }
    }  
    class Program
    {
        static void Main(string[] args)
        {
            FruitAbstractFactory fruitfactory = new AppleFactory();//苹果工厂  
            Console.WriteLine(fruitfactory.GetCurrentFruit());
            Console.ReadLine();
            fruitfactory = new BananaFactory();//香蕉工厂  
            Console.WriteLine(fruitfactory.GetCurrentFruit());
            Console.ReadLine();
            fruitfactory = new TangerineFactory();//橘子工厂  
            Console.WriteLine(fruitfactory.GetCurrentFruit());  
            Console.ReadKey();
        }
    }
}
