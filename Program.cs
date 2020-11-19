using System;
using System.Collections.Generic;
using System.Linq;

namespace LinqDemo
{
    struct Student{
        public string name;
        public int age;
        public int grade;
        public float score;
    }
    class Program
    {
        /// <summary>
        /// 基本使用
        /// </summary>
        static void Linq1() {
            #region 构造查询数据
            List<Student> stuList = new List<Student>();
            Random random = new Random();
            for (int i=0;i<50;i++) {
                float sc = random.Next(0,100);
                int age = random.Next(8,13);
                int gde = random.Next(1,6);
                string name = "";
                switch (random.Next(0, 6))
                {
                    case 1: name = "周xxx"; break;
                    case 2: name = "李xxx"; break;
                    case 3: name = "孙xxx"; break;
                    case 4: name = "钱xxx"; break;
                    default: name = "赵xxx"; break;
                }
                Student st = new Student();
                st.name = name;
                st.age = age;
                st.grade = gde;
                st.score = sc;
                stuList.Add(st);
            }
            #endregion
            //lamada表达式写法
            //查询分数小于60的人员,并按照分数降序排序
            var query = from r in stuList where r.score < 60 orderby r.score descending select r;
            //var list = stuList.Where(r => r.score < 60).OrderByDescending(r => r.score).Select(r=>r);
            Console.WriteLine("不及格人员名单");
            foreach (Student st in query) {
                Console.WriteLine("姓名:"+st.name);
                Console.WriteLine("班级:"+st.grade);
                Console.WriteLine("年龄:"+st.age);
                Console.WriteLine("分数:"+st.score);
            }
            Console.ReadKey();
        }
        /// <summary>
        /// 延迟查询 只需构造一次查询语句，可以多次使用
        /// 例如下面的代码尽管查询在第二次添加数据之前,但添加数据后再调用一次之前的查询结果会发现新添加的数据也能够查询出来
        /// </summary>
        /// <param name="args"></param>
        static void Linq2() {
            #region 构造查询数据
            List<string> lists = new List<string> { "Jack", "Pet", "Hant", "Li", "Kkk" };

            #endregion
            //var query = from r in lists where r.StartsWith("J") select r;
            var query = lists.Where(r => r.StartsWith("J")).Select(r => r);
            Console.WriteLine("第一次查询结果：");
            foreach (string st in query)
            {
                Console.WriteLine(st);
            }

            Console.WriteLine("第二次查询结果：");
            lists.Add("Jone");
            lists.Add("Jimi");
            lists.Add("Johu");
            foreach (string st in query)
            {
                Console.WriteLine(st);
            }

            Console.ReadKey();
        }
        static void Main(string[] args)
        {
            //Linq1();
            Linq2();
        }
    }
}
