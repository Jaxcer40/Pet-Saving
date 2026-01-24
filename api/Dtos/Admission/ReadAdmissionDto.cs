using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Dtos.Admission
{
    public class ReadAdmissionDto
    {
        public int Id { get; set; }

        // llave foranea hacia Patient
        public PatientSummaryDto Patient {get; set;}=null!;

        // llave foranea hacia Vet
        public VetSummaryDto Vet {get; set;}=null!;

        public DateTime AdmissionDate { get; set; }

        public DateTime? DischargeDate { get; set; }

        public string AdmissionReason { get; set; } = string.Empty;

        public string CageNumber { get; set; } = string.Empty;


    }

    public class PatientSummaryDto
    {
        public string Name {get; set;} = string.Empty;
        public string Species { get; set; } = string.Empty;

    }

    public class VetSummaryDto
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName {get;set;}= string.Empty;
        public string Specialization { get; set; } = string.Empty;
    }

}