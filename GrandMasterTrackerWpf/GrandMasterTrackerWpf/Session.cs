using System;
using System.Collections.Generic;

namespace GrandMasterTrackerWpf
{
    class Session
    {
        public DateTime dateTime;
        public List<Run> runs = new List<Run>();

        public Session()
        {
            dateTime = new DateTime();
        }
    }
}
