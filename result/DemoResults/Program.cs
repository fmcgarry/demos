using DemoResults;

var userService = new UserService();

var result = userService.AddUser("Testy", "");
//var result = userService.AddUser("Ted", "");

if (result.IsSuccessful)
{
    var user = result.Data!;
    Console.WriteLine($"User '{user.FirstName} {user.LastName}' added successfully!");
}
else
{
    foreach (var error in result.Errors)
    {
        Console.WriteLine(error);
    }
}
//else
//{
//    Console.WriteLine("User was not valid:");

//    foreach (var error in result.Errors)
//    {
//        Console.WriteLine(error);
//        Console.WriteLine($"  - {error}");
//    }
//}
