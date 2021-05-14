using System;
using System.Collections.Generic;
using System.Linq;
using Timesheets.Data.Interfaces;
using Timesheets.Models;

namespace Timesheets.Data.Implementation
{
    public class SheetRepo: ISheetRepo
    {
        private static List<Sheet> Sheets { get; set; } = new List<Sheet>()
        {
            new Sheet
            {
                Id = Guid.Parse("A185AB18-8FB5-D2E8-8748-E60B532A36F7"),
                EmployeeId = Guid.Parse("BAE0AD5E-3953-C234-A716-D5455534E457"),
                ContractId = Guid.Parse("AABD059A-915D-DA7D-2351-7D4439404782"),
                ServiceId = Guid.Parse("81499FA0-A92A-5356-BFAF-2A655DBD8033"), Amount = 3
            },
            new Sheet
            {
                Id = Guid.Parse("F4501D5F-487C-9635-6A1E-C65D2E07E4C0"),
                EmployeeId = Guid.Parse("D72DB79E-4536-2957-835C-660B74C59EEE"),
                ContractId = Guid.Parse("8715FBAF-E2AE-78F6-A7F8-9EBDA9E24D9F"),
                ServiceId = Guid.Parse("993BF7FD-5EB5-512F-1561-446F6BA9A4F2"), Amount = 6
            },
        };
        
        public Sheet GetItem(Guid id)
        {
            var result = Sheets.FirstOrDefault(x => x.Id == id);

            return result;
        }

        public IEnumerable<Sheet> GetItems()
        {
            throw new NotImplementedException();
        }

        public void Add(Sheet item)
        {
            Sheets.Add(item);
        }

        public void Add()
        {
            throw new NotImplementedException();
        }

        public void Update()
        {
            throw new NotImplementedException();
        }
    }
}