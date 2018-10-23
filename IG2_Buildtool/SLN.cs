using System;
using System.Collections.Generic;
using System.Text;

namespace IG2_Buildtool
{
    public class SLN
    {
        public string Name { get; private set; }
        public string Component { get; private set; }
        public string Path { get; private set; }
        public List<string> tags { get; private set; }

        public SLN(string name, string component, string path, List<string> tags)
        {
            this.Name = name;
            this.Component = component;
            this.Path = path;
            this.tags = tags;
        }
        public override bool Equals(object obj)
        {
            var item = obj as SLN;

            if (item == null)
            {
                return false;
            }

            return this.Name.Equals(item.Name);
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        public override string ToString()
        {
            return Name;
        }
    }
}
