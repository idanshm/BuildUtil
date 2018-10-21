using System;
using System.Xml;

namespace IG2_Buildtool
{
    class XmlTree
    {
        public readonly Tree<string> xmlTree;
        private XmlDocument xmlDoc;
        private string branches;
        public XmlTree(string path,string _nodes)
        {
            branches = _nodes;
            xmlTree = new Tree<string>();
            xmlDoc = new XmlDocument();
            xmlDoc.Load(path);
            createTree();
        }
        private void createTree()
        {
            XmlNodeList nodes = xmlDoc.DocumentElement.SelectNodes(branches);
            foreach (XmlNode node in nodes)
            {
                foreach (var child in node.ChildNodes)
                {
                    if (child.GetType() == typeof(XmlElement))
                    {
                        XmlElement elem=(XmlElement)child;
                        var father = elem.SelectSingleNode("Parent");
                        var name = elem;
                        if (father != null || !father.InnerText.Contains("None"))
                        {
                            xmlTree.AddNode(name.Attributes["name"].Value, father.InnerText);
                        }
                        else
                        {
                            xmlTree.AddNode(name.Attributes["name"].Value);
                        }
                    }
                }
                
            }
        }
        public void ShowTree()
        {
            int level=-1;
            foreach (Node<string> t in xmlTree)
            {
                if (level != t.level)
                {
                    
                    Console.Write("{0}\n", t.level);
                    level = t.level;
                }
                else
                {
                    Console.Write("{0}\t", t.level);
                }
            }
        }

    }
}
