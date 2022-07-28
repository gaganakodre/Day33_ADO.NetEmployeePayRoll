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
    }
}