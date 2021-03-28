using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 解释器模式
{
    /*文法规则
  <expression> ::= <city>的<person>
  <city> ::= 韶关|广州
  <person> ::= 老人|妇女|儿童
*/

//抽象表达式类
interface Expression
{
     Boolean interpret(String info);
}
//终结符表达式类
class TerminalExpression : Expression
{
    private List<String> list= new List<String>();
    public TerminalExpression(String[] data)
    {
        for(int i=0;i<data.Count();i++)list.Add(data[i]);
    }
    public Boolean interpret(String info)
    {
        if(list.Contains(info))
        {
            return true;
        }
        return false;
    }
}
//非终结符表达式类
class AndExpression : Expression
{
    private Expression city=null;    
    private Expression person=null;
    public AndExpression(Expression city,Expression person)
    {
        this.city=city;
        this.person=person;
    }
    public Boolean interpret(string info)
    {
        string[] s=info.Split('的');  
             
        return city.interpret(s[0])&& person.interpret(s[1]);
    }
}
//环境类
class Context
{
    private String[] citys={"韶关","广州"};
    private String[] persons={"老人","妇女","儿童"};
    private Expression cityPerson;
    public Context()
    {
        Expression city=new TerminalExpression(citys);
        Expression person=new TerminalExpression(persons);
        cityPerson=new AndExpression(city,person);
    }
    public void freeRide(String info)
    {
        Boolean ok=cityPerson.interpret(info);
        if(ok) Console.WriteLine("您是"+info+"，您本次乘车免费！");
        else Console.WriteLine(info+"，您不是免费人员，本次乘车扣费2元！");   
    }
}
    class Program
    {
        static void Main(string[] args)
        {
            Context bus = new Context();
            bus.freeRide("韶关的老人");
            bus.freeRide("韶关的年轻人");
            bus.freeRide("广州的妇女");
            bus.freeRide("广州的儿童");
            bus.freeRide("山东的儿童");
            Console.ReadKey();
        }
    }
}
