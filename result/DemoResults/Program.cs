using ResultDemo;

var userService = new UserService();

var result = userService.AddUser("Testy", "McTesterton");

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
