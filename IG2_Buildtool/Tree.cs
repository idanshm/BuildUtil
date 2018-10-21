using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace IG2_Buildtool
{
    class Tree<T> : IEnumerable
    {
        TreeNode root;
        
        public Tree()
        {
           
            this.root = new TreeNode();
            
        }
        public void AddNode(T data,T parent)
        {
            var tempNode = FindNode(data);
           
            TreeNode nodeParent = FindNode(parent);
            if (nodeParent == null)
            {
                nodeParent = new TreeNode(parent, root);
                root.AddChild(nodeParent);
            }
            if (tempNode != null)
            {
                if (tempNode.parent == root)
                {
                    nodeParent.AddChild(tempNode);
                    tempNode.parent = nodeParent;
                    if (tempNode.childrens != null)
                    {
                        foreach (var n in tempNode.childrens)
                        {
                            n.level = tempNode.level + 1;
                        }
                    }
                    root.DeleteChild(data);
                    return;
                }
            }

            TreeNode nodeLeaf = new TreeNode(data, nodeParent);
            nodeParent.AddChild(nodeLeaf);

        }
        public void AddNode(T data)
        {
            TreeNode nodeLeaf = new TreeNode(data, root);
            root.AddChild(nodeLeaf);

        }


        public void DeleteNode(T data)
        {
            var node= FindNode(data);
            if (node.childrens != null)
            {
                node.parent.childrens.AddRange(node.childrens);
            }
            node.parent.DeleteChild(data);
        }
        private TreeNode FindNode(T data)
        {
            if (this.root.childrens == null)
                return null;
            Queue<TreeNode> nodes = new Queue<TreeNode>(this.root.childrens);

            while (nodes.Count != 0)
            {
                TreeNode node = nodes.Dequeue();
                if (node.childrens != null)
                {
                    foreach (TreeNode item in node.childrens)
                    {
                        nodes.Enqueue(item);
                    }
                }
                if (node.data.Equals(data))
                {
                    return node;
                }
            }
            return null;
        }
        public List<T> Parents(T data)
        {
            TreeNode node=FindNode(data);
            List<T> list = new List<T>(node.level);
            while (node.parent!=root)
            {

                list.Add(node.parent.data);
                node = node.parent;
            }
            return list;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            Queue<TreeNode> nodes = new Queue<TreeNode>(this.root.childrens);

            while (nodes.Count != 0)
            {
                TreeNode treeNode = nodes.Dequeue();
                Node<T> node=new Node<T>(treeNode.data, treeNode.level);
                yield return node;
                if (treeNode.childrens != null)
                {
                    foreach (TreeNode item in treeNode.childrens)
                    {
                        nodes.Enqueue(item);
                    }
                }
            }
        }

        private class TreeNode
        {
            public readonly T data;
            public TreeNode parent;
            public int level;
            public List<TreeNode> childrens;
            public TreeNode()
            {
                parent = null;
                level = 0;
            }

            public TreeNode(T data ,TreeNode parent)
            {
                this.data = data;
                level = parent.level + 1;
                this.parent = parent;
            }
            
            public void AddChild(TreeNode child)
            {
                if (childrens == null)
                {
                    childrens = new List<TreeNode>();
                }
                child.level = this.level + 1;
                childrens.Add(child);
            }
            public void DeleteChild(T _data)
            {
                int index = childrens.FindIndex(node => node.data.Equals(_data));
               
                childrens.RemoveAt(index);
            }

            
        }

    }
}
