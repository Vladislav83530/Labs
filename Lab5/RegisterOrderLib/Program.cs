using RegisterOrderLib.DataValidator;
using RegisterOrderLib.Models;

var dataFormatValidator = new DataFormatValidator(@"^\+380\d{9}$", @"^[^\s@]+@[^\s@]+\.[^\s@]+$");
var sqlInjectionValidator = new SqlInjectionValidator();
var xssValidator = new XssValidator();

dataFormatValidator.SetNext(sqlInjectionValidator);
sqlInjectionValidator.SetNext(xssValidator);

Order validOrder = new Order
{
    FirstName = "Test",
    LastName = "Test",
    MiddleName = "Test",
    PhoneNumber = "+380678951414",
    Email = "test@gmail.com",
    Address = "Ukraine, Kyiv",
    DeliveryType = DeliveryType.ExpressDelivery,
    PostOfficeNumber = 12
};

Order invalidOrder = new Order
{
    FirstName = "",
    LastName = "Test <script>",
    MiddleName = "Test",
    PhoneNumber = "+380678951414",
    Email = "test@gmail.com insert",
    Address = "Ukraine, Kyiv",
    DeliveryType = DeliveryType.ExpressDelivery,
    PostOfficeNumber = 12
};

ValidationResult result = dataFormatValidator.Validate(validOrder, new ValidationResult());
Console.WriteLine($"Data format: {result.FormatDataResult} - {result.FormatDataMessage}");
Console.WriteLine($"Sql injection: {result.SqlInjectionaResult} - {result.SqlInjectionMessage}");
Console.WriteLine($"Xss atact: {result.XssResult} - {result.XssMessage}");
Console.WriteLine();

ValidationResult result2 = dataFormatValidator.Validate(invalidOrder, new ValidationResult());
Console.WriteLine($"Data format: {result2.FormatDataResult} - {result2.FormatDataMessage}");
Console.WriteLine($"Sql injection: {result2.SqlInjectionaResult} - {result2.SqlInjectionMessage}");
Console.WriteLine($"Xss atact: {result2.XssResult} - {result2.XssMessage}");