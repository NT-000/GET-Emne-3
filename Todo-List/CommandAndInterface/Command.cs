using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Todo_List
{
    internal class Command
    {
        abstract void Run();
        string No { get; }
        private string Description { get; }

    }
}
