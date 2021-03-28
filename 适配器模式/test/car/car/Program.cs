using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace car
{
    //目标：发动机
    interface Motor
    {
        void drive();
    }
    //适配者：电能发动机
    class ElectricMotor
    {
        public void electricDrive()
        {
            Console.WriteLine("电能发动机驱动汽车");
        }
    }
    //适配者2：光能发动机
    class OpticlMotor
    {
        public void opticDrive()
        {
            Console.WriteLine("光能发动机驱动汽车");
        }
    }
    //电能适配器
    class ElectricAdapter : Motor
    {
        private ElectricMotor emotor;
        public ElectricAdapter()
        {
            emotor = new ElectricMotor();
        }
        public void drive()
        {
            emotor.electricDrive();
        }
    }
    //光能适配器
    class OpticalAdapter : Motor
    {
        private OpticlMotor omotor;
        public OpticalAdapter()
        {
            omotor = new OpticlMotor();
        }
        public void drive()
        {
            omotor.opticDrive();
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Motor motor = (Motor)ReadXML.getObject();
            motor.drive();
            Console.ReadKey();
        }
    }
    class ReadXML
    {
        //该方法用于从XML配置文件中提取具体类类名，并返回一个实例对象
        public static Object getObject()
        {
            string path = @"C:\Users\19215\Desktop\适配器模式\test\config.xml";
            // XmlDouument doc = new XmlDouument();
            XmlDocument doc = new XmlDocument();
            doc.Load(path);
            XmlNodeList nodes = doc.DocumentElement.GetElementsByTagName("className");
            //XmlElement classNode=nodes.Item(0).InnerText;
            String cName = "car." + nodes.Item(0).InnerText;
            Console.WriteLine("新类名：" + cName);
            //System.out.println("新类名："+cName);
            //通过类名生成实例对象并将其返回
            Type o = Type.GetType(cName);//加载类型
            object obj = Activator.CreateInstance(o, true);//根据类型创建实例
            return obj;


        }
    }
}
