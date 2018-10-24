using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;

namespace IG2_Buildtool
{
    class ProjectBuilder
    {

        public void BuildAll(XmlTree Xmltree)
        {
            List <Task> tasks = new List<Task>();
            int level = 1;
            int count = 0;
            foreach (Node<SLN> x in Xmltree.xmlTree)
            {
                if (level == x.level)
                {
                    tasks.Add(Task.Factory.StartNew(() => Build(string.Format(@"D:\Repos\Devline-Balmas\MainBranch\{0}{1}", x.data.Path,x.data.Name))));
                }
                else
                {
                    Task.WaitAll(tasks.ToArray());
                    tasks.Clear();
                    level = x.level;
                    tasks.Add(Task.Factory.StartNew(() => Build(string.Format(@"D:\Repos\Devline-Balmas\MainBranch\{0}{1}", x.data.Path, x.data.Name))));
                }
                count++;
            }
        }

        static void Build(object thing)
        {
            var p = new Process();
            p.StartInfo = new ProcessStartInfo(@"C:\Program Files (x86)\MSBuild\12.0\Bin\msbuild.exe");
            p.StartInfo.Arguments = thing.ToString();
            p.Start();
            //Console.WriteLine(thing);
        }

        public bool PreTests()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Starting pre tests verifications..");
            XmlTree xml = CreateXmlTreeObject();
            CheckMsBuild2013();
            CheckSLNPath(xml);
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
            if (!File.Exists(@"C:\Program Files (x86)\MSBuild\12.0\Bin\msbuild.exe"))
            {
                Console.WriteLine(@"Error: C:\Program Files (x86)\MSBuild\12.0\Bin\msbuild.exe not exist.");
                return false;
            }
            Console.WriteLine(@"MsBuild 12.0 found at C:\Program Files (x86)\MSBuild\12.0\Bin\msbuild.exe");
            return true;
        }

        private bool CheckSLNPath(XmlTree Xmltree)
        {
            string projectRoot = @"D:\Repos\Devline-Balmas\MainBranch";
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
                }
            }
            return true;
        }
    }
}
