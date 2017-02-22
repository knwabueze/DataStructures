using DataStructures.Collections;
using DataStructures.Sorting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentTracker
{
    public class StudentTracker : BinarySearchTree<Student>
    {
        private static int GUID = 0;

        public StudentTracker(params Student[] students) : base(students)
        {
            GUID = 0;
        }

        public StudentTracker() : base()
        {
            GUID = 0;
        }

        public new void Insert(Student value)
        {
            GUID++;
            value.UniqueID = GUID;

            base.Insert(value);
            this.Sort();
        }

        public void Remove(string name)
        {
            var arr = InOrderTraverse();

            var query =
                from t in arr
                where t.Value.Name == name
                select t.Value;

            Remove(query.First());
            this.Sort();
        }

        public void Remove(int uniqueID)
        {
            var arr = InOrderTraverse();

            var query =
                from t in arr
                where t.Value.UniqueID == uniqueID
                select t.Value;

            Remove(query.First());
            this.Sort();
        }

        public Student Search(string name)
        {
            return SearchNode(name).Value;
        }

        public Student Search(int uid)
        {
            return SearchNode(uid).Value;
        }

        public BinarySearchTreeNode<Student> SearchNode(string name)
        {
            var arr = InOrderTraverse();

            var query =
                from t in arr
                where t.Value.Name == name
                select t;

            return query.First();
        }

        public BinarySearchTreeNode<Student> SearchNode(int uid)
        {
            var arr = InOrderTraverse();

            var query =
              from t in arr
              where t.Value.UniqueID == uid
              select t;

            return query.First();
        }
    }
}
