using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Healthcare.DataAccess
{
    public class Visit : BaseModel
    {
        [ForeignKey("Patient")]
        public int PatientId { get; set; }
        public virtual Patient Patient { get; set; }

        public DateTime Date { get; set; }
        [StringLength(500)]
        public string Text { get; set; }
    }
}
