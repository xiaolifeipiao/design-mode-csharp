using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 里式替换

{
    //override和new的相同点：都是子类在重新实现父类中签名相同的方法时使用。
    //                       当声明一个子类对象时，调用这个方法，调用的都是子类中实现的方法。


    //override和new的不同点：
    //override：父类方法必须用virtual修饰，表示这个方法是虚方法，可以被重写。否则不能被重写。
    //new : 　　父类方法不必使用virtual修饰。
    //override :重写后，当子类对象转换为父类时，无法访问被重写的虚方法。也就是，被子类重写后，虚方法在子类对象中便失效了。
    //new : 覆盖后，当子类对象转换为父类，可以访问被覆盖的父类方法。也就是，转换为父类后，子类new的方法便失效了，此时调用的是父类方法。
    //当其再转换为子类时，调用的又变为子类方法。




    //动物类
    class Animal
    {
        double runSpeed;
        public void setRunSpeed(double speed)
        {
            runSpeed = speed;
        }
        public double getRunTime(double distance)
        {
            return (distance / runSpeed);
        }
    }
    //鸟类
   class Bird:Animal
    {
       public double flySpeed;
        public virtual void setSpeed(double speed)
        {
            flySpeed = speed;
        }
        public double getFlyTime(double distance)
        {
            return (distance / flySpeed);
        }
    }
    //燕子类
    class Swallow : Bird
    {

    }
    //
    class BrownKiwi : Animal
    {
        
    }
    class Program
    {
        static void Main(string[] args)
        {
            Bird bird1 = new Swallow();
            Animal bird2 = new Animal();
            bird1.setSpeed(120);
            bird2.setRunSpeed(120);
            try
            {
                Console.WriteLine("燕子飞行" + bird1.getFlyTime(300) + "小时");
                Console.WriteLine("几维鸟跑" + bird2.getRunTime(300) + "小时");
            }
            catch (Exception err)
            {
                Console.WriteLine("出错了");
            }
            Console.ReadKey();
        }
    }
}
