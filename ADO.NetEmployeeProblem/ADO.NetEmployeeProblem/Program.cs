﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADO.NetEmployeeProblem
{
    public class Program
    {
        public static void Main(string[] args)
        {
            EmployeeRepository employeeRepo = new EmployeeRepository();
            EmployeePayRoll model = new EmployeePayRoll();
            Console.WriteLine("Enter the choice \n 1.AddingEmployee\n 2.UpdateEmployee");
            int choice=Convert.ToInt32(Console.ReadLine());
            switch(choice)
            {
                case 1:
                    model.Name = "Gagana";
                    model.Department = "HR";
                    model.Address = "3rd main";
                    model.Phone = 1234565432;
                    model.BasicPay = 3000000;
                    model.StartDate = "2004-09-08";
                    model.Gender = "F";
                    model.TaxablePay = 79000;
                    model.NetPay = 6588;
                    model.IncomTax = 5676;
                    model.Deductions = 2345;
                    employeeRepo.AddEmployee(model);
                    employeeRepo.GetAllEmployees();
                    break;
                case 2:
                    
                    model.BasicPay = 3000001;
                    model.Name = "Shree";
                    employeeRepo.UpdateEmployee(model);
                    employeeRepo.GetAllEmployees();
                    break;
            }
            
        }
    }
}