using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ServerClient
{
    public class ProjectInfo
    {
        public string Path { get; set; }

        public ProjectInfo(string path)
        {
            this.Path = path;
        }
    }
}
