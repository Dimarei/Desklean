using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desklean
{
     class Queue
    {
        public bool isDirectory { get; set; }
        public string source { get; set; }
        public string dest { get; set; }
        public DateTime moveTime { get; set; }

        public Queue(bool isDirectory, string source, string dest, DateTime moveTime)
        {
            this.isDirectory = isDirectory;
            this.source = source;
            this.dest = dest;
            this.moveTime = moveTime;
        }
    }
}
