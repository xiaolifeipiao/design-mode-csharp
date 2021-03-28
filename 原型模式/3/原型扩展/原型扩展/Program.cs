using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 原型扩展
{
    interface Shape : ICloneable
    {
         Object Clone();//拷贝
         void countArea();//计算面积
    }
    class Circle : Shape
    {
        public Object Clone()
        {
            Circle w = null;
            try
            {
                w = (Circle)this.MemberwiseClone();
            }
            catch(Exception e ){
                Console.WriteLine("拷贝圆失败");
            }
            return w;
        }
        public void countArea()
        {
            int r = 0;
            Console.WriteLine("这是一个圆，请输入半径：");
             r = Convert.ToInt32(Console.ReadLine());
             
            Console.WriteLine("该圆的面积=" + 3.14 * r * r + "\n");
        }
    }
    class Square : Shape
    {
        public Object Clone()
    {
        Square b=null;
        try
        {
            b=(Square)this.MemberwiseClone();
        }
        catch(Exception e)
        {
            Console.WriteLine("拷贝正方形失败!");
        }
        return b;
    }
        public void countArea()
    {
        int a=0;
        Console.WriteLine("这是一个正方形，请输入它的边长：");
        a=Convert.ToInt16(Console.ReadLine());
        
            Console.WriteLine("该正方形的面积="+a*a+"\n");
    }
    }
    class ProtoTypeManager
    {
        private Dictionary<String, Shape> ht = new Dictionary<String, Shape>();
        public ProtoTypeManager()
        {
            ht.Add("Circle", new Circle());
            ht.Add("Square", new Square());
        }
        public void addshape(String key, Shape obj)
        {
            ht.Add(key, obj);
        }
        public Shape getShape(String key)
        {
            Shape temp;
            ht.TryGetValue(key, out temp);
            return (Shape)temp.Clone();
        }
    }
    class Program
    {
        static void Main(string[] args)
        
        {
            ProtoTypeManager pm = new ProtoTypeManager();
            Shape obj1 = (Circle)pm.getShape("Circle");
            obj1.countArea();
            Shape obj2 = (Shape)pm.getShape("Square");
            obj2.countArea();
            Console.ReadKey();
        }
    }
}
