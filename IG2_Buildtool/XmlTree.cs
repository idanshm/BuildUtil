using System;
using System.Collections.Generic;
using System.Xml;

namespace IG2_Buildtool
{
    class XmlTree
    {
        public readonly Tree<SLN> xmlTree;
        private XmlDocument xmlDoc;
        private string branches;
        public XmlTree(string path,string _nodes)
        {
            branches = _nodes;
            xmlTree = new Tree<SLN>();
            xmlDoc = new XmlDocument();
            xmlDoc.Load(path);
            createTree();
        }
        private void createTree()
        {
            XmlNodeList nodes = xmlDoc.DocumentElement.SelectNodes(branches);
            Stack<(SLN,SLN)> stack = new Stack<(SLN, SLN)>();
            
            foreach (XmlNode node in nodes)
            {
                foreach (var child in node.ChildNodes)
                {
                    if (child.GetType() == typeof(XmlElement))
                    {
                        XmlElement elem=(XmlElement)child;
                        var father = elem.SelectSingleNode("Parent");
                        
                        SLN sln = parseData(elem);
                        SLN parent = new SLN(father.InnerText, "", "", null);
                        if (father != null && !father.InnerText.Contains("None"))
                        {
                            if (!xmlTree.AddNode(sln, parent))
                            {
                               stack.Push((sln, parent));
                            }
                        }
                        else
                        {
                            xmlTree.AddNode(sln);
                        }
                    }
                }
                
            }
            while (stack.Count != 0)
            {
                var item = stack.Pop();
                if (!xmlTree.AddNode(item.Item1, item.Item2))
                {
                    stack.Push(item);
                }
            }


        }
       private SLN parseData(XmlElement elem)
        {
            string name = elem.Attributes["name"].Value;
            string path = elem.SelectSingleNode("Path").InnerText;
            string component = elem.SelectSingleNode("Component").InnerText;
            List<string> tags = new List<string>(elem.SelectSingleNode("Tags").InnerText.Split(' '));
            SLN sln = new SLN(name, component, path, tags);
            return sln;
        }

    }
}
