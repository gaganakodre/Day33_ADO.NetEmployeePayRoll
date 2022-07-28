using Newtonsoft.Json;
using RestSharp;
using System.Net;

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
    }
}