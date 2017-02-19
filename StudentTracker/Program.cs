using DataStructures.Collections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentTracker
{
    class Program
    {
        static void Main(string[] args)
        {
            StudentTracker studentTracker = new StudentTracker();

            for (int i = 0; i < 20; ++i)
            {
                string email = "student" + i.ToString() + "@schoolacademy.org";
                studentTracker.Insert(new Student()
                {
                    Name = i.ToString(),
                    Email = email,
                    DateOfBirth = new DateTime(1999, 10, i + 1)
                });
            }

            studentTracker.Remove("1");

            studentTracker.Insert(new Student()
            {
                Name = "Jerry Johnson",
                Email = "jerryjohsnon@schoolacademy.org",
                DateOfBirth = new DateTime(2004, 9, 3)
            });

            Console.WriteLine("---END---");
        }
    }
}
