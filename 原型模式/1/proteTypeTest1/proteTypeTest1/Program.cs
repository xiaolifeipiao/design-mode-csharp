using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proteTypeTest1
{

     class Realizetype : ICloneable
    {
         public Realizetype()
        {
            Console.WriteLine("具体原型创建成功");
        }
        public Object Clone() {
            Console.WriteLine("具体原型复制成功");
            return (Realizetype)this.MemberwiseClone();
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Realizetype obj1 = new Realizetype();
            Realizetype obj2 = (Realizetype)obj1.Clone();
            Console.WriteLine("obj1=obj2" + (obj1 == obj2));
            Console.ReadKey();
        }
    }
}
