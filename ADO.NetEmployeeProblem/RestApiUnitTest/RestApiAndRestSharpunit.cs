using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using System.Net;
using System.Text.Json.Nodes;

namespace RestApiAndRestSharpEmployeePayRoll
{
    public class Employee
    {
        public int id { get; set; } 
        public string first_name { get; set; }
        public string last_name{ get; set; }
        public string email { get; set; }

        
    }
    public class Tests
    {
        RestClient client;

        [SetUp]
        public void Setup()
        {
            client = new RestClient("http://localhost:4000");
        }
        private RestResponse getEmployeeList()
        {
            RestRequest request = new RestRequest("/employees", Method.Get);

            RestResponse response = client.Execute(request);
            return response;
        }

        [Test]
        public void OnCallingGETApi_ReturnEmployeeList()
        {
            RestResponse response = getEmployeeList();
            Assert.AreEqual(response.StatusCode, HttpStatusCode.OK);
            List<Employee> dataResponse = JsonConvert.DeserializeObject<List<Employee>>(response.Content);
            Assert.AreEqual(7, dataResponse.Count);

            foreach (Employee e in dataResponse)
            {
                System.Console.WriteLine("id: " + e.id + ",FirstName: " + e.first_name +  ",LastName: " + e.last_name + ",Email" + e.email);
            }
        }
        [Test]
        public void givenEmployee_OnPost_ShouldReturnAddedEmployee()
        {
            RestRequest request = new RestRequest("/employees", Method.Post);
            JsonObject jObjectbody = new JsonObject();
            jObjectbody.Add("first_name", "Ganesh");
            jObjectbody.Add("last_name", "jhonny");
            jObjectbody.Add("email", "jho@gmail.com");
            request.AddParameter("application/json", jObjectbody, ParameterType.RequestBody);
            RestResponse response = client.Execute(request);
            Assert.AreEqual(response.StatusCode, HttpStatusCode.Created);
            Employee dataResponse = JsonConvert.DeserializeObject<Employee>(response.Content);
            Assert.AreEqual("Ganesh", dataResponse.first_name);
            Assert.AreEqual("jhonny", dataResponse.last_name);
            Assert.AreEqual("jho@gmail.com", dataResponse.email);

        }
        [Test]
        public void GivenMultipleEmployee_OnPost_ThenShouldReturnEmployeeList()
        {
            List<Employee> employeeList = new List<Employee>();
            employeeList.Add(new Employee { first_name = "Vinaya", last_name="jaya",email="jaya@gmail.com" });
            employeeList.Add(new Employee { first_name = "Rudra", last_name = "magic", email = "Rudra@gmail.com" });
            employeeList.Add(new Employee { first_name = "Peppa", last_name = "Pig", email = "MB@gmail.com" });
            employeeList.Add(new Employee { first_name = "Masha", last_name = "Bear", email = "PP@gmail.com" });
            foreach (var employeeData in employeeList)
            {
                RestRequest request = new RestRequest("/employees", Method.Post);
                JsonObject jObjectBody = new JsonObject();
                jObjectBody.Add("first_name", employeeData.first_name);
                jObjectBody.Add("last_name", employeeData.last_name);
                jObjectBody.Add("email", employeeData.email);
                request.AddParameter("application/json", jObjectBody, ParameterType.RequestBody);
                RestResponse response1 = client.Execute(request);
                Assert.AreEqual(response1.StatusCode, HttpStatusCode.Created);
                Employee dataResorce1 = JsonConvert.DeserializeObject<Employee>(response1.Content);
                Assert.AreEqual(employeeData.first_name, dataResorce1.first_name);
                Assert.AreEqual(employeeData.last_name, dataResorce1.last_name);
                Assert.AreEqual(employeeData.email, dataResorce1.email);
                System.Console.WriteLine(response1.Content);
            };

            RestResponse response = getEmployeeList();
            Assert.AreEqual(response.StatusCode, HttpStatusCode.OK);
            List<Employee> dataResorce = JsonConvert.DeserializeObject<List<Employee>>(response.Content);
            Assert.AreEqual(12, dataResorce.Count);
        }
        [Test]
        public void GivenEmployee_WhenUpdateSalary_ThenShouldReturnUpdatedEmployeeSalary()
        {
            RestRequest request = new RestRequest("/employees/10", Method.Put);
            JsonObject jObjectBody = new JsonObject();
            jObjectBody.Add("first_name", "Mouna");
            jObjectBody.Add("last_name", "water");
            jObjectBody.Add("email", "mouna@gmail.com");
            request.AddParameter("application/json", jObjectBody, ParameterType.RequestBody);
            RestResponse response = client.Execute(request);
            Assert.AreEqual(response.StatusCode, HttpStatusCode.OK);
            Employee dataResorce = JsonConvert.DeserializeObject<Employee>(response.Content);
            Assert.AreEqual("Mouna", dataResorce.first_name);
            Assert.AreEqual("water", dataResorce.last_name);
            Assert.AreEqual("mouna@gmail.com", dataResorce.email); ;
            Console.WriteLine(response.Content);
        }
    }
}