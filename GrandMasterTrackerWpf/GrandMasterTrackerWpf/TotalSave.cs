using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrandMasterTrackerWpf
{
    class TotalSave
    {
        public int totalShards;
        public int totalExoitcs;
        public int totalRuns;
        public double averageShards;
        public double averageExoitcs;

        public void Save(int totalShards, int totalExoitcs, int totalRuns, double averageShards, double averageExoitcs)
        {
            this.totalShards = totalShards;
            this.totalExoitcs = totalExoitcs;
            this.totalRuns = totalRuns;
            this.averageShards = averageShards;
            this.averageExoitcs = averageExoitcs;
        }
    }
}
