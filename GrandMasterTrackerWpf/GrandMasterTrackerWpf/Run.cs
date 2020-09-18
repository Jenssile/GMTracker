using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrandMasterTrackerWpf
{
    class Run
    {
        public int shards;
        public int exotics;

        public Run(int shards, int exotics)
        {
            this.shards = shards;
            this.exotics = exotics;
        }
    }
}
