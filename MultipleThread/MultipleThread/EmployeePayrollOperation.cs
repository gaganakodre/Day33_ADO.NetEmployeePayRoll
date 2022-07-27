using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MultipleThread
{
    /// <summary>
    /// UC1-non threads
    /// </summary>
    public class EmployeePayrollOperation
    {
        List<EmployeeDetails> list = new List<EmployeeDetails>();
        public void addEmployeeToPayRoll(List<EmployeeDetails> list)
        {
            list.ForEach(employeedata =>
            {
                Console.WriteLine("Employee Being Added:" + employeedata.Name);
                this.addEmployeeToPayRoll(employeedata);
                Console.WriteLine("Employee added:" + employeedata.Name);
            });
            Console.WriteLine(this.list.ToString());    
        }
        //public void addEmployeePayRollWithThread(List<EmployeeDetails> list)
        //{
        //    list.ForEach(employeedata =>
        //    {
        //        Task thread = new Task(() =>
        //        Console.WriteLine("employee being added:" + employeedata.Name);
        //        this.addEmployeeToPayRoll(employeedata);
        //        Console.WriteLine("employee  added:" + employeedata.Name);
        //    });
        //    thread.Start();
        //});
        //Console.WriteLine(this.list.Count);
        //}
        //UC_2 Adding Employee and calculating Execution Time Using Thread.
        public void AddEmployee_UsingThread(List<EmployeeDetails> list)
        {
            list.ForEach(employeeData =>
            {
                Task thread = new Task(() =>
                {
                    Console.WriteLine("Employee_Being_Added : " + employeeData.Name);
                    this.addEmployeeToPayRoll(employeeData);
                    Console.WriteLine("Employee_Added :" + employeeData.Name);
                });
                thread.Start();
            });
            Console.WriteLine(this.list.Count);
        }

        //Adds the employee to payroll.
        public void addEmployeeToPayRoll(EmployeeDetails employeedata)
        {
            list.Add(employeedata);
        }
    }
}
