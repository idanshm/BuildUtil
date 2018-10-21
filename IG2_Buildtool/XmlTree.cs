using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace IG2_Buildtool
{
    class XmlTree
    {
        Tree<string> xmlTree;
        private XmlDocument xmlDoc;
        private string branches;
        public XmlTree(string path,string _nodes)
        {
            branches = _nodes;
            xmlTree = new Tree<string>();
            xmlDoc = new XmlDocument();
            xmlDoc.Load(path);
           
        }
        private void createTree()
        {
            XmlNodeList nodes = xmlDoc.DocumentElement.SelectNodes(branches);
            Console.WriteLine(nodes);
            foreach (XmlNode node in nodes)
            {
                var father = node.SelectSingleNode("father");
                var name = node.SelectSingleNode("FirstName");
                if (father != null)
                {
                    xmlTree.AddNode(name.InnerText, father.InnerText);
                }
                else
                {
                    xmlTree.AddNode(name.InnerText);
                }
            }
        }
    }
}
