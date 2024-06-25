

using System;

namespace Core.Models
{
    public  class SupportCallInQueues
    {
        public string SupporCallID { get; set; }
        public int Number { get; set; }

        public string Types { get; set; }

        public string  Summary { get; set; }

        public string Queue { get; set; }

        public string  Status { get; set; }

        public DateTime OpenDate { get; set; }

        public DateTime DueDate { get; set; }
    }
}
