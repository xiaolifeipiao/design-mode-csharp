using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test
{
    //产品角色：包含多个组成部件的复杂对象。
    class Product
    {
        private string partA;
        private string partB;
        private string partC;
        public void setPartA(string partA)
        {
            this.partA = partA;
        }
        public void setPartB(string partB)
        {
            this.partB = partB;
        }
        public void setPartC(string partC)
        {
            this.partC = partC;
        }
        public void show()
        {
            //显示产品的特性
            Console.WriteLine("产品特性："+partA+partB+partC);
        }
    }
    //抽象建造者：包含创建产品各个子部件的抽象方法。
    abstract class Builder
    {
        //创建产品对象
        protected Product product = new Product();
        public abstract void buildPartA();
        public abstract void buildPartB();
        public abstract void buildPartC();
        //返回产品对象
        public Product getResult()
        {
            return product;
        }
    }
    //具体建造者：实现了抽象建造者接口。
     class ConcreteBuilder : Builder
    {
         public override void buildPartA()
        {
            product.setPartA("建造者A");
        }
         public override void buildPartB()
        {
            product.setPartB("建造者B");
        }
         public override void buildPartC()
        {
            product.setPartC("建造者C");
        }
    }
    //指挥者：调用建造者中的方法完成复杂对象的创建。
    class Director
    {
        private Builder builder;
        public Director(Builder builder)
        {
            this.builder = builder;
        }
        //产品构建与组装方法
        public Product construct()
        {
            builder.buildPartA();
            builder.buildPartB();
            builder.buildPartC();
            return builder.getResult();
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Builder builder = new ConcreteBuilder();
            Director directer = new Director(builder);
            Product product = directer.construct();
            product.show();
            Console.ReadKey();
        }
    }
}
