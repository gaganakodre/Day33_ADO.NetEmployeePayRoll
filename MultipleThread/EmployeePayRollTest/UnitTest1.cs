namespace MultipleThread
{
    public class Tests
    {
        EmployeeDetails empDetails;

        [SetUp]
        public void Setup()
        {
            EmployeeDetails empDetails;
        }

        [Test]
        public void Given10Employee_whenAddedToList_shouldMatchEmployeeEntries()
        {
            List<EmployeeDetails> list = new List<EmployeeDetails>();
            list.Add(new EmployeeDetails(employeeID: 1, name:"shree", department:"cse", address:"Bengaluru", phone:45536, basicPay:4313, startDate:"01-05-1988",gender:"F",taxablePay:1635563, netPay:751,incomTax:543,deductions:54));
            list.Add(new EmployeeDetails(employeeID: 2, name: "ganesha", department: "Ise", address: "Mysore", phone: 45531, basicPay: 4253, startDate: "01-05-1998", gender: "M", taxablePay: 2635563, netPay: 752, incomTax: 32543, deductions: 154));
            list.Add(new EmployeeDetails(employeeID: 3, name: "chandru", department: "ECE", address: "hubli", phone: 45532, basicPay: 4453, startDate: "01-05-2000", gender: "M", taxablePay: 3635563, netPay: 753, incomTax: 2543, deductions: 254));
            list.Add(new EmployeeDetails(employeeID: 4, name: "gagana", department: "EEE", address: "Darvada", phone: 45533, basicPay: 4553, startDate: "01-05-2001", gender: "F", taxablePay: 4635563, netPay: 754, incomTax: 5543, deductions: 354));
            list.Add(new EmployeeDetails(employeeID: 5, name: "gowri", department: "CIVIL", address: "belgavi", phone: 45534, basicPay: 43653, startDate: "01-05-2002", gender: "F", taxablePay: 5635563, netPay: 755, incomTax: 3543, deductions: 454));
            list.Add(new EmployeeDetails(employeeID: 6, name: "thunga", department: "MECH", address: "davanagere", phone: 45535, basicPay: 554353, startDate: "01-05-2003", gender: "F", taxablePay:51635563, netPay: 575, incomTax:3543, deductions: 554));
            list.Add(new EmployeeDetails(employeeID: 7, name: "godavari", department: "Ise", address: "haveri", phone: 45536, basicPay: 44353, startDate: "01-05-2004", gender: "F", taxablePay: 7635563, netPay: 775, incomTax: 3543, deductions: 654));
            list.Add(new EmployeeDetails(employeeID: 8, name: "yamune", department: "cse", address: "tumakuru", phone: 45537, basicPay: 784353, startDate: "01-05-1978", gender: "F", taxablePay: 8635563, netPay: 375, incomTax: 543, deductions: 754));
            list.Add(new EmployeeDetails(employeeID: 9, name: "krishna", department: "CIVIL", address: "hasana", phone: 45538, basicPay: 74353, startDate: "01-05-2019", gender: "F", taxablePay: 65635563, netPay: 575, incomTax: 1543, deductions: 854));
            list.Add(new EmployeeDetails(employeeID: 10, name: "badra", department: "AI", address: "Bengaluru", phone: 45539, basicPay: 54353, startDate: "01-05-2016", gender: "M", taxablePay: 6735563, netPay: 375, incomTax: 9543, deductions: 954));
            EmployeePayrollOperation employeePayrollOperation = new EmployeePayrollOperation();
            employeePayrollOperation.addEmployeeToPayRoll(empDetails);

            DateTime startDateTime= DateTime.Now;
            employeePayrollOperation.addEmployeeToPayRoll(list);
            DateTime stopDateTime= DateTime.Now;
            Console.WriteLine("Duration without thread:" + (stopDateTime - startDateTime));

            DateTime starttimeThread = DateTime.Now;
            employeePayrollOperation.AddEmployee_UsingThread(list);
            DateTime stopdateTimeThread = DateTime.Now;
            Console.WriteLine("Duration without thread:" + (stopdateTimeThread - starttimeThread));

        }
    }
}