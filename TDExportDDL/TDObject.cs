using System;

namespace TDExportDDL
{
    class TDObject
    {
        public string Database { get; set; }
        public string Name { get; set; }
        public string TDType { get; set; }
        public string Body { get; set; }
        public DateTime SnapshotDate { get; set; }
    }
}
