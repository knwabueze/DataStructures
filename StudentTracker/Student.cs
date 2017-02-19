using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentTracker
{
    public class Student : IComparable
    {
        public int UniqueID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime DateOfBirth { get; set; }

        public int CompareTo(object obj)
        {
            Student student2 = obj as Student;
            return UniqueID - student2.UniqueID;
        }

        public override string ToString()
        {
            return UniqueID.ToString() + " - " + Name.ToString() + ", " + Email.ToString() + ", born on: " + DateOfBirth.ToString();
        }
    }
}
