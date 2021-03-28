using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 模板方法模式test
{
    //抽象类：出国留学
    abstract class StudyAbroad
    {
        public void TemplateMethod()//模板方法
        {
            LookingForSchool();//索取学校资料
            ApplyForEnrol();//入学申请
            ApplyForPassport();//办理因出国护照，出境卡和公正
            ReadyGoAbroad();//体检,订机票，中北行装
            ApplyForVisa();//申请签证
            Arriving();//抵达
        }
        public void ApplyForPassport()
        {
            Console.WriteLine("三.办理因私出国护照、出境卡和公证：");
            Console.WriteLine("  1）持录取通知书、本人户口簿或身份证向户口所在地公安机关申请办理因私出国护照和出境卡。");
            Console.WriteLine("  2）办理出生公证书，学历、学位和成绩公证，经历证书，亲属关系公证，经济担保公证。");
        }
        public void ApplyForVisa()
    {
        Console.WriteLine("四.申请签证：");
        Console.WriteLine("  1）准备申请国外境签证所需的各种资料，包括个人学历、成绩单、工作经历的证明；个人及家庭收入、资金和财产证明；家庭成员的关系证明等；");
        Console.WriteLine("  2）向拟留学国家驻华使(领)馆申请入境签证。申请时需按要求填写有关表格，递交必需的证明材料，缴纳签证。有的国家(比如美国、英国、加拿大等)在申请签证时会要求申请人前往使(领)馆进行面试。");
    }
        public void ReadyGoAbroad()
    {
        Console.WriteLine("五.体检、订机票、准备行装：");
        Console.WriteLine("  1）进行身体检查、免疫检查和接种传染病疫苗；");
        Console.WriteLine("  2）确定机票时间、航班和转机地点。");
    }
        public abstract void LookingForSchool();//索取学校资料
        public abstract void ApplyForEnrol();   //入学申请
        public abstract void Arriving();        //抵达
    }
    //具体子类：美国留学
    class StudyInAmerica : StudyAbroad
    {
        public override void LookingForSchool()
        {
            
            Console.WriteLine("一.索取学校以下资料：");
            Console.WriteLine("  1）对留学意向国家的政治、经济、文化背景和教育体制、学术水平进行较为全面的了解；");
            Console.WriteLine("  2）全面了解和掌握国外学校的情况，包括历史、学费、学制、专业、师资配备、教学设施、学术地位、学生人数等；");
            Console.WriteLine("  3）了解该学校的住宿、交通、医疗保险情况如何；");
            Console.WriteLine("  4）该学校在中国是否有授权代理招生的留学中介公司？");
            Console.WriteLine("  5）掌握留学签证情况；");
            Console.WriteLine("  6）该国政府是否允许留学生合法打工？");
            Console.WriteLine("  8）毕业之后可否移民？");
            Console.WriteLine("  9）文凭是否受到我国认可？");
        }
        public override void ApplyForEnrol()
    {
        Console.WriteLine("二.入学申请：");
        Console.WriteLine("  1）填写报名表；");
        Console.WriteLine("  2）将报名表、个人学历证明、最近的学习成绩单、推荐信、个人简历、托福或雅思语言考试成绩单等资料寄往所申请的学校；");
        Console.WriteLine("  3）为了给签证办理留有充裕的时间，建议越早申请越好，一般提前1年就比较从容。");       
    }
    
    public override void Arriving()
    {
        Console.WriteLine("六.抵达目标学校：");
        Console.WriteLine("  1）安排住宿；");
        Console.WriteLine("  2）了解校园及周边环境。");
    }
    }
    class Program
    {
        static void Main(string[] args)
        {
            StudyAbroad tm = new StudyInAmerica();
            tm.TemplateMethod();
            Console.ReadKey();
        }
    }
}
