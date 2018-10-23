using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;

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
            int count = 0;
            foreach (Node<SLN> x in xmlTree.xmlTree)
            {
                if (level == x.level)
                {
                    tasks.Add(Task.Factory.StartNew(() => build(string.Format(@"D:\Repos\Devline-Balmas\MainBranch\{0}{1}", x.data.Path,x.data.Name))));
                }
                else
                {
                    Task.WaitAll(tasks.ToArray());
                    tasks.Clear();
                    level = x.level;
                    tasks.Add(Task.Factory.StartNew(() => build(string.Format(@"D:\Repos\Devline-Balmas\MainBranch\{0}{1}", x.data.Path, x.data.Name))));
                }
                count++;
                
               
            }
        }

        static void build(object thing)
        {
            var p = new Process();
            p.StartInfo = new ProcessStartInfo(@"C:\Program Files (x86)\MSBuild\12.0\Bin\msbuild.exe");
            p.StartInfo.Arguments = thing.ToString();
            p.Start();
            //Console.WriteLine(thing);
        }
    }
}
