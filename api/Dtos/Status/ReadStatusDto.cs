using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Dtos.Status
{
    public class ReadStatusDto
    {
        public int Id { get; set; }

        // llave foranea hacia Admission
        public AdmissionSummaryDto Admission {set; get;}=null!;

        public string CurrentStatus { get; set; } = string.Empty;

        public string Notes { get; set; } = string.Empty;
    }

    public class AdmissionSummaryDto
    {
        public DateTime AdmissionDate { get; set; }
        public string AdmissionReason { get; set; } = string.Empty;
        
    }

}