using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;
using System.Collections.Specialized;
using System.Configuration;


namespace IG2_Buildtool
{
    class ProjectBuilder
    {
        NameValueCollection appsettings = ConfigurationManager.AppSettings;
        public void BuildAll()
        {
            if (PreTests())
            {
                XmlTree Xmltree = CreateXmlTreeObject();
                List<Task> tasks = new List<Task>();
                int level = 1;
                int count = 0;
                foreach (Node<SLN> x in Xmltree.xmlTree)
                {
                    if (level == x.level)
                    {
                        tasks.Add(Task.Factory.StartNew(() => Build(string.Format($@"{appsettings["project_root"]}\{x.data.Path}{x.data.Name}"))));
                    }
                    else
                    {
                        Task.WaitAll(tasks.ToArray());
                        tasks.Clear();
                        level = x.level;
                        tasks.Add(Task.Factory.StartNew(() => Build(string.Format($@"{appsettings["project_root"]}\{x.data.Path}{x.data.Name}", x.data.Path, x.data.Name))));
                    }
                    count++;
                }
            }
            return;
        }

        private void Build(object thing)
        {
            var p = new Process();
            p.StartInfo = new ProcessStartInfo($@"{appsettings["msbuild2013"]}");
            p.StartInfo.Arguments = thing.ToString();
            p.Start();
            //Console.WriteLine(thing);
        }

        public bool PreTests()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Starting Pre-Tests verifications...");
            XmlTree xml = CreateXmlTreeObject();
            if (!CheckMsBuild2013() || !CheckSLNPath(xml))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Pre-Tests failed!\n");
                Console.ForegroundColor = ConsoleColor.White;
                return false;
            }
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("All Pre-Tests passed successfully!\n");
            Console.ForegroundColor = ConsoleColor.White;
            return true;
        }

        private XmlTree CreateXmlTreeObject()
        {
            string CompilationOrderListPath = Path.GetFullPath(@"..\..\..\Configs\CompilationOrder.List");
            XmlTree xmlTree = new XmlTree(CompilationOrderListPath, "/Root/CompilationOrder");
            return xmlTree;
        }

        private bool CheckMsBuild2013()
        {
            if (!File.Exists($@"{appsettings["msbuild2013"]}"))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($@"Error: {appsettings["msbuild2013"]} not exist.");
                Console.ForegroundColor = ConsoleColor.White;
                return false;
            }
            Console.WriteLine($@"MsBuild 12.0 found at {appsettings["msbuild2013"]}");
            return true;
        }

        private bool CheckSLNPath(XmlTree Xmltree)
        {
            string projectRoot = $@"{appsettings["project_root"]}";
            bool isPathOk = true;
            foreach (Node<SLN> x in Xmltree.xmlTree)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("Checking path " + $"{projectRoot}{x.data.Path}{x.data.Name}....");
                if (File.Exists($"{projectRoot}{x.data.Path}{x.data.Name}"))
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("OK!");
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Failed!");
                    Console.ForegroundColor = ConsoleColor.White;
                    isPathOk = false;
                }
            }
            if (!isPathOk)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("One or more solutions could not be found!");
                Console.ForegroundColor = ConsoleColor.White;
                return false;
            }
            return true;
        }
    }
}
