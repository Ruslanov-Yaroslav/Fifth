using System;
using System.Collections.Generic;

namespace Delegat
{
    class Program
    {
        public delegate string Del(string a);

        static void Main(string[] args)
        {
            Func<User , bool> sortedFunc = SortFunc;
            List<User> users = new List<User> {new User("Anton" , "M" , 19) , 
                                                new User("Ana", "W", 22) , 
                                                new User("Yaroslav", "M", 28) , 
                                                new User("Vova" , "M" , 17)};
            var result = Filter(users, sortedFunc);
            foreach(var i in result)
            {
                Console.WriteLine(i.ToString());
            }

            Del cut = Cut;
            Console.WriteLine(cut("Hello EPAM - I'm ready to work"));

            Del remove = Remove;
            Console.WriteLine(remove("Hello EPAM - I'm ready to work   "));

            Del addSpace = AddSpace;
            Console.WriteLine(addSpace("Hello EPAM - I'm ready to work"));

            Del multipleDel = null;
            multipleDel += Cut;
            multipleDel += Remove;
            multipleDel += AddSpace;
            string multResult = "Hello world bla bla";
            foreach (Del d in multipleDel.GetInvocationList())
            {
                multResult = d(multResult);
            }
            Console.WriteLine(multResult);
            
        }

        static List<User> Filter(List<User> a, Func<User , bool> b)
        {
            List<User> res = new List<User>();
            if(a != null)
            {
                foreach(var us in a)
                {
                    if (b(us))
                    {
                        res.Add(us);
                    }
                }
            }
            return res;
        }

        static bool SortFunc(User a)
        {
            var ret = a.Age < 20 ? true : false;
            return ret;
        }

        static string Cut(string a)
        {
            var res = a.Length > 12 ? a.Substring(0 , 12) : a;
            return res;
        }

        static string Remove(string a)
        {
            var res = a.Contains(".") ? a.TrimEnd('.') : a ;
            return res;
        }

        static string AddSpace(string a)
        {
            return a += "...";
        }
    }
}
        

