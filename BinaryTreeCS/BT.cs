using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTree
{
    unsafe public class BT<T>
        where T : new()
    {
        private T data;
        private int level;
        private BT<T> left;
        private BT<T> right;
        private BT<T> parent;

        public BT()
        {
            this.level = 0;
            left = null;
            right = null;
            parent = null;
        }
        public BT(T d)
        {
            this.data = d;
            this.level = 0;
            left = null;
            right = null;
            parent = null;
        }
        private static bool IsLessThan(T a, T b) { return Compare(a, b, -1); } //comparing generic types
        private static bool IsBiggerThan(T a, T b) { return Compare(a, b, 1); }
        private static bool IsEqualTo(T a, T b) { return Compare(a, b, 0); }
        private static bool Compare(T a, T b, int res)
        {
            Comparer<T> comparer = Comparer<T>.Default;
            return comparer.Compare(a, b) == res ? true : false;
        }
        public void add_node(T d)
        { //adding nodes to the binary search tree
            if (this.left == null && IsBiggerThan(this.data, d))
            {
                this.left = new BT<T>(d);
                this.left.level = this.level + 1;
                this.left.parent = this;
            }
            else if (this.right == null && IsLessThan(this.data, d))
            {
                this.right = new BT<T>(d);
                this.right.level = this.level + 1;
                this.right.parent = this;
            }
            else
            {
                if (IsBiggerThan(this.data, d)) this.left.add_node(d);
                else if (IsLessThan(this.data, d)) this.right.add_node(d);
            }
        }

        public void traverse()
        { //traversing the tree
            Console.Write(this.data + " ");
            if (this.left != null) this.left.traverse();
            if (this.right != null) this.right.traverse();
        }

        public BT<T> search(T n)
        {
            if (IsEqualTo(this.data, n))
            {
                return this;
            }
            else if (IsBiggerThan(this.data, n) && this.left != null) return this.left.search(n);
            else if (IsLessThan(this.data, n) && this.right != null) return this.right.search(n);
            else
            {
                BT<T> temp = new BT<T>();
                Console.WriteLine("This node does not exist");
                return temp;
            }
        }
        public void delete_node(T d)
        {
            BT<T> n = this.search(d);
            BT<T> temp = new BT<T>();
            if (!IsEqualTo(n.data, temp.data))
            {
                BT<T> p = n.parent;
                if (n.left == null && n.right == null)//deleting the leaf
                {
                    if (p.left == n) p.left = null;
                    else if (p.right == n) p.right = null;
                }
                else if (n.left == null || n.right == null)//when the element we want to delete has one child
                {
                    if (n.left == null)
                        if (p.left == n) p.left = n.right;
                        else p.right = n.right;
                    else
                        if (p.left == n) p.left = n.right;
                    else p.right = n.right;
                }
                else //when the element we want to delete has two children
                {
                    BT<T> s = n.right;
                    n.data = s.data;
                    if (s.parent.left == s)
                    {
                        s.parent.left = s.right;
                        if (s.right != null) s.right.parent = s.parent;
                    }
                    else
                    {
                        s.parent.right = s.left;
                        if (s.left != null) s.right.parent = s.parent;
                    }
                }
            }
        }
        public void full_print() //printing the full tree
        {
            string space = "";
            for (int i = 0; i < this.level; ++i)
            {
                space += "  ";
            }
            Console.WriteLine(space + this.data.ToString());
            if (left != null && right != null)
            {
                left.full_print();
                right.full_print();
            }
            else if (left == null && right != null) right.full_print();
            else if (left != null && right == null) left.full_print();
            else return;
        }
        public void leaves_print()
        { //prints only leaves
            if (left == null && right == null)
            {
                Console.Write(this.data.ToString() + " ");
            }
            if (right != null) right.leaves_print();
            if (left != null) left.leaves_print();
        }
        public T get_parent()
        {
            if (this.parent != null) return this.parent.data;
            else
            {
                BT<T> temp = new BT<T>();
                return temp.data;
            }
        }
        public T get_data()
        {
            return this.data;
        }
        public T get_left()
        {
            if (this.left != null) return this.left.data;
            else
            {
                BT<T> temp = new BT<T>();
                return temp.data;
            }
        }
        public T get_right()
        {
            if (this.right != null) return this.right.data;
            else
            {
                BT<T> temp = new BT<T>();
                return temp.data;
            }
        }
    }
}
