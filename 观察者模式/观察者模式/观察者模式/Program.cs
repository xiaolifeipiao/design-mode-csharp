using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace 观察者模式
{
    //抽象目标
    abstract class Subject
    {
        protected List<Observer> observers = new List<Observer>();
        public void add(Observer observer)
        {
            observers.Add(observer);
        }
        public void remove(Observer observer)
        {
            observers.Remove(observer);
        }
        //通知观察者方法
        public abstract void notifyObserver();
    }
    //具体目标
    class ConcreteSubject : Subject
    {
        public override void notifyObserver()
        {
            Console.WriteLine("具体目标发生变化...");
            Console.WriteLine("----------------");
            foreach (var i in observers)
            {
                i.response();
            }
        }
    }
    //抽象观察者
    interface Observer
    {
        void response();//反应
    }
    //具体观察者1
    class ConcreteObserver1 : Observer
    {
        public new void response()
        {
            Console.WriteLine("具体观察者1做出反应");
        }
    }
    //具体观察者2
    class ConcreteObserver2 : Observer
    {
        public new void response()
        {
            Console.WriteLine("具体观察者2做出反应");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Subject s = new ConcreteSubject();
            Observer ob1 = new ConcreteObserver1();
            Observer ob2 = new ConcreteObserver2();
            s.add(ob1);
            s.add(ob2);
            s.notifyObserver();
            Console.ReadKey();
        }
    }
}
