using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultipleThread
{
    public class EmployeeDetails
    {
        
            public int EmployeeID { get; set; }
            public string Name { get; set; }
            public string Department { get; set; }
            public string Address { get; set; }
            public int Phone { get; set; }
            public float BasicPay { get; set; }
            public string StartDate { get; set; }
            public string Gender { get; set; }

            public float TaxablePay { get; set; }

            public float NetPay { get; set; }
            public float IncomTax { get; set; }
            public double Deductions { get; set; }
        public EmployeeDetails(int employeeID, string name, string department, string address, int phone, float basicPay, string startDate, string gender, float taxablePay, float netPay, float incomTax, double deductions)
        {
            EmployeeID = employeeID;
            Name = name;
            Department = department;
            Address = address;
            Phone = phone;
            BasicPay = basicPay;
            StartDate = startDate;
            Gender = gender;
            TaxablePay = taxablePay;
            NetPay = netPay;
            IncomTax = incomTax;
            Deductions = deductions;
        }
    }
}
