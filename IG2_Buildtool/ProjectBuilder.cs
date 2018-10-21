﻿using System;
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
            List<Task> tasks = new List<Task>();
            int level = 1;
            foreach (Node<string> x in xmlTree.xmlTree)
            {
                if (level == x.level)
                {
                    tasks.Add(Task.Factory.StartNew(() => SaySomething(x.data + " level:" + x.level)));
                }
                else
                {
                    Task.WaitAll(tasks.ToArray());
                    tasks.Clear();
                    level = x.level;
                    tasks.Add(Task.Factory.StartNew(() => SaySomething(x.data + " level:" + x.level)));
                }
            }
        }

        static void SaySomething(object thing)
        {
            /*Process cmd = new Process();
            cmd.StartInfo.FileName = "cmd.exe";
            cmd.StartInfo.RedirectStandardInput = true;
            cmd.StartInfo.RedirectStandardOutput = true;
            cmd.StartInfo.CreateNoWindow = true;
            cmd.StartInfo.UseShellExecute = false;
            cmd.Start();

            cmd.StandardInput.WriteLine("echo Oscar");
            cmd.StandardInput.Flush();
            cmd.StandardInput.Close();
            cmd.WaitForExit();
            Console.WriteLine(cmd.StandardOutput.ReadToEnd());*/
            Console.WriteLine(thing);
        }
    }
}
