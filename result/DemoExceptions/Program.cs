using DemoExceptions;

var userService = new UserService();

try
{
    var user = userService.AddUser("Testy", "McTesterton");
    //var user = userService.AddUser("Ted", "Tedderson");
    Console.WriteLine($"User '{user.FirstName} {user.LastName}' added successfully!");
}
catch (Exception e)
{
    Console.WriteLine(e.Message);
}