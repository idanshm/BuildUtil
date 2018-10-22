using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.IO;

namespace IG2_Buildtool
{
    class ProjectBuilder
    {
        public void BuildAll()
        {
            string CompilationOrderListPath = Path.GetFullPath(@"..\..\..\Configs\CompilationOrder.List");
            XmlTree xmlTree = new XmlTree(CompilationOrderListPath, "/Root/CompilationOrder");
            
            List <Task> tasks = new List<Task>();
            int level = 1;
            foreach (Node<SLN> x in xmlTree.xmlTree)
            {
                if (level == x.level)
                {
                    tasks.Add(Task.Factory.StartNew(() => build(x.data + " level:" + x.level)));
                }
                else
                {
                    Task.WaitAll(tasks.ToArray());
                    tasks.Clear();
                    level = x.level;
                    tasks.Add(Task.Factory.StartNew(() => build(x.data + " level:" + x.level)));
                }
            }
        }

        static void build(object thing)
        {
           // var p = new Process();
           // p.StartInfo = new ProcessStartInfo(@"C:\Windows\Microsoft.NET\Framework\v4.0.30319\msbuild.exe");
           // p.StartInfo.Arguments = @"C:\example\project.csproj";
           // p.Start();
            Console.WriteLine(thing);
        }
    }
}
