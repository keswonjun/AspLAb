using ASPnetlab1;

var builder = WebApplication.CreateBuilder(args);
builder.Configuration
    .AddJsonFile("configcompanies.json")
    .AddXmlFile("configcompanies.xml")
    .AddIniFile("configcompanies.ini")
    .AddJsonFile("MeInfoConfig.json");
var app = builder.Build();

var config = builder.Configuration;

app.Run(async (context) =>
{
    context.Response.ContentType = "text/html; charset=utf-8";

    var companies = new List<Company>();

    var myInfo = config.GetSection("MyInfo").GetChildren().First();
    var myName = myInfo["MyName"];
    var age = myInfo["Age"];
    var group = myInfo["Group"];

    foreach (var section in config.GetChildren())
    {
        var name = section.Key;
        var stocksCount = section.GetValue<long>("StocksCount");
        var stocksPrice = section.GetValue<float>("StocksPrice");
        var employees = section.GetValue<int>("EmployeesCount");

        companies.Add(new Company(name, stocksCount, stocksPrice, employees));
    }

    var companyWithMostEmployees = companies.OrderByDescending(c => c.Employees).First();

    await context.Response.WriteAsync($"<p>Name: {companyWithMostEmployees.Name}</p>" +
                                      $"<p>Share Count: {companyWithMostEmployees.StocksCount}</p>" +
                                      $"<p>Share Price: {companyWithMostEmployees.StocksPrice}</p>" +
                                      $"<p>Employees: {companyWithMostEmployees.Employees}</p>"+
                                      $"<h2>MyInfo</h2>"+
                                      $"<p>Name: {myName}</p>" +
                                      $"<p>Age: {age}</p>" +
                                      $"<p>Group: {group}</p>");
});

app.Run();