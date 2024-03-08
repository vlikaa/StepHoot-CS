
using StepHoot_C_;
using UserLibrary;

var stepHoot = new StepHoot();

// Console.WriteLine(stepHoot.Registration(new User
// {
//     Name = "Name",
//     Surname = "Surname",
//     Phone = "555-333",
//     Login = "Login",
//     Password = "Password"
// }));

Console.WriteLine(UserHelper.IsCorrectUser(new User
{
    Name = "Name",
    Surname = "Surname",
    Phone = "0513379420",
    Login = "Valie_gi50",
    Password = "Password"
}));

