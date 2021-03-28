using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 迪米特法则
{
    class Agent
    {
        private Star myStar;
        private Fans myFans;
        private Company myCompany;
        public void setStar(Star myStar)
        {
            this.myStar = myStar;
        }
        public void setFans(Fans myFans)
        {
            this.myFans = myFans;
        }
        public void setCompany(Company myCompany)
        {
            this.myCompany = myCompany;
        }
        public void meeting()
        {
            Console.WriteLine(myFans.getName() + "与明星" + myStar.getName() + "见面了");
        }
         public void business()
    {
        Console.WriteLine(myCompany.getName() + "与明星" + myStar.getName() + "洽淡业务。");
    }
    }
    //明星
    class Star
    {
        private String name;
        public Star(String name)
        {
            this.name = name;
        }
        public String getName()
        {
            return name;
        }
    }
    //粉丝
    class Fans
    {
        private String name;
        public Fans(String name)
        {
            this.name = name;
        }
        public String getName()
        {
            return name;
        }
    }
    //媒体公司
    class Company
    {
        private String name;
        public Company(String name)
        {
            this.name = name;
        }
        public String getName()
        {
            return name;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Agent agent = new Agent();
            agent.setStar(new Star("林心如"));
            agent.setFans(new Fans("粉丝韩丞"));
            agent.setCompany(new Company("中国传媒有限公司"));
            agent.meeting();
            agent.business();
            Console.ReadKey();
        }
    }
}
