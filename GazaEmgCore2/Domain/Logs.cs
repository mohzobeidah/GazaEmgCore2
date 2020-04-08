using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GazaEmgCore2.Domain
{
    public class Logs
    {
        public int Id { get; set; }
        public string EventType { get; set; }
        public string TableName { get; set; }
        public string ColumnName { get; set; }
        public int RecordId { get; set; }
        public string OriginalValue { get; set; }
        public string NewValue { get; set; }
        public string InsertUser { get; set; }
        public DateTime InsertDate { get; set; }
        public string CreatedBy { get; set; }
    }
}
