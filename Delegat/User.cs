using System;
using System.Collections.Generic;
using System.Text;

namespace Delegat
{
    class User
    {
        public string Name { get; set; }
        public string Gender { get; set; }
        public int Age { get; set; }
        public  List<User> users;
        public User(string name, string gender, int age)
        {
            Name = name;
            Gender = gender;
            Age = age;
            users = new List<User>();
        }
        public override string ToString()
        {
            return $"Name is {Name}; Gender is {Gender}; Age is {Age}";
        }
    }
}
