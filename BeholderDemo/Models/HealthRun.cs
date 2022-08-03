using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeholderDemo.Models
{
    public class HealthRun
    {
        public Guid Id { get; set; }
        public string ConfigurationId { get; set; }
        public string Domain { get; set; }
        public string Partition { get; set; }
        public DateTime LastRun { get; set; }
        public TimeSpan Duration { get; set; }
        public bool IsOk { get; set; }
        public string Description { get; set; }
        public int Retry { get; set; }
        public int StatusCode { get; set; }
    }
}
