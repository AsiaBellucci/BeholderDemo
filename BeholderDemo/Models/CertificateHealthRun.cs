using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BeholderDemo.Models
{
    public class CertificateHealthRun
    {
        public string Domain { get; set; }
        public DateTime CertificateNotBefore { get; set; }
        public DateTime CertificateNotAfter { get; set; }
        public DateTime LastRun { get; set; }
        [JsonIgnore]
        public bool IsValid => DateTime.UtcNow < CertificateNotAfter && DateTime.UtcNow > CertificateNotBefore;
    }
}
