using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace test
{
    //抽象产品，提供产品的接口
    interface Product
    {
         void show();
    }
    //具体产品1：实现抽象产品的抽象方法
    class ConcreteProduct1 : Product
    {
        public void show()
        {
            Console.WriteLine("产品1显示");
        }
    }
    //具体产品2：实现抽象产品中的抽象方法
   class ConcreteProduct2:Product
    {
        public void show()
        {
            Console.WriteLine("具体产品2显示...");
        }
    }
    //抽象工厂：提供产品的生产方法
   interface AbstractFactory
   {
        Product newProduct();
   }
    //具体工厂1：提供产品生成方法
   class ConcreteFactory1 : AbstractFactory
   {
       public Product newProduct()
       {
           Console.WriteLine("具体工厂1生成-->具体产品1...");
           return new ConcreteProduct1();
       }
   }
    //具体工厂2：实现了厂品的生成方法
    class ConcreteFactory2:AbstractFactory
    {
        public Product newProduct()
        {
            Console.WriteLine("具体工厂2生成-->具体产品2...");
            return new ConcreteProduct2();
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            try{
                Product a;
                AbstractFactory af;
                af = (AbstractFactory)ReadXML1.getObject();
                a = af.newProduct();
                a.show();
            }
            catch(Exception e){
                Console.WriteLine(e.Message);
            }
            Console.ReadKey();
        }
    }
    class ReadXML1
    {
        //该方法用于从XML配置文件中提取具体类类名，并返回一个实例对象
        public static Object getObject()
        {
            string XMLFileName = @"C:\Users\19215\Desktop\工厂方法模式\config1.xml";
            // XmlDouument doc = new XmlDouument();
            XmlDocument doc = new XmlDocument();
            doc.Load(XMLFileName);
            XmlNodeList nodes = doc.DocumentElement.GetElementsByTagName("className");
            //XmlElement classNode=nodes.Item(0).InnerText;
            String cName = "test." + nodes.Item(0).InnerText;
            Console.WriteLine("新类名：" + cName);
            //System.out.println("新类名："+cName);
            //通过类名生成实例对象并将其返回
            Type o = Type.GetType(cName);//加载类型
            object obj = Activator.CreateInstance(o, true);//根据类型创建实例
            return obj;

        
    }
    }
}
