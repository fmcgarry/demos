using ResultDemo;

var userService = new UserService();

try
{
    var user = userService.AddUser("Testy", "McTesterton");
    Console.WriteLine($"User '{user.FirstName} {user.LastName}' added successfully!");
}
catch (Exception e)
{
    Console.WriteLine(e.Message);
}