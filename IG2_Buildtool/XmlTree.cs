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
            Dictionary<string,(SLN,string)> dic = new Dictionary<string, (SLN,string)>();
            
            foreach (XmlNode node in nodes)
            {
                foreach (var child in node.ChildNodes)
                {
                    if (child.GetType() == typeof(XmlElement))
                    {
                        XmlElement elem=(XmlElement)child;
                        var father = elem.SelectSingleNode("Parent");
                        if (father == null)
                            return;
                        SLN sln = parseData(elem);
                        string parent = father.InnerText;
                        if (father.InnerText.Contains("None"))
                        {
                            xmlTree.AddNode(sln);
                            dic.Add(sln.Name, (sln, ""));

                        }
                        else
                        {
                            xmlTree.AddNode(sln);
                            dic.Add(sln.Name, (sln,parent));
                        }
                    }
                }
                
            }
           foreach (string key in dic.Keys)
            {

                SLN child = dic[key].Item1;
                var k = dic[key].Item2;
                if (!k.Equals(""))
                {
                    SLN par = dic[k].Item1;
                    xmlTree.AddParent(child, par);
                }
            }
            Console.WriteLine("fds");

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
