using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TRMS_API.VewModel
{
    public class RequestViewModel
    {
        public int RequestId { get; set; }
        public string CauseTravel { get; set; }
        public string Source { get; set; }
        public string Destination { get; set; }
        public string Mode { get; set; }
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
        public int? NoOfDays { get; set; }
        public string Priority { get; set; }
        public string ProjectName { get; set; }
        public string FirstName { get; set; }
        public string Status { get; set; }
    }
}
