using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 代理模式
{
    //抽象主题（Subject）类：通过接口或抽象类声明真实主题和代理对象实现的业务方法。
    //真实主题（Real Subject）类：实现了抽象主题中的具体业务，是代理对象所代表的真实对象，是最终要引用的对象。
    //代理（Proxy）类：提供了与真实主题相同的接口，其内部含有对真实主题的引用，它可以访问、控制或扩展真实主题的功能
    //抽象主题
    interface Subject
    {
        void Request();
    }
    //真实主题
    class RealSubject : Subject
    {
        public void Request()
        {
            Console.WriteLine("访问真实主题方法");
        }
    }
    //代理
    class Proxy : Subject
    {
        private RealSubject realSubject;
        public void Request()
        {
            if (realSubject == null)
            {
                realSubject = new RealSubject();
            }
            preRequest();
            realSubject.Request();
            postRequest();
        }
        public void preRequest()
        {
            Console.WriteLine("访问真是主题之前");
        }
        public void postRequest()
        {
            Console.WriteLine("访问真实主题之后");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Proxy proxy = new Proxy();
            proxy.Request();
            Console.ReadKey();
        }
    }
}
