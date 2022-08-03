using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeholderDemo.Models
{
    public class HealthLog
    {
        public string Domain { get; set; }
        public DateTime CertificationExpiringTime => Certificate?.CertificateNotAfter ?? DateTime.MaxValue;
        public bool Status => Runs.Any(x => x.IsOk) && Certificate?.IsValid != false;
        public CertificateHealthRun Certificate { get; set; }
        public List<HealthRun> Runs { get; set; }
    }
}
