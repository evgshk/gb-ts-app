using System;
using System.Collections.Generic;

namespace Timesheets.Models
{
    public class Invoice
    {
        public Guid Id { get; set; }
        public Guid ContractId { get; set; }
        public DateTime DateStart { get; set; }
        public DateTime DateEnd { get; set; }
        public decimal Sum { get; set; }

        public Contract Contract { get; set; }
        public List<Sheet> Sheets { get; set; } = new List<Sheet>();
    }
}