
using StepHoot_C_;
using UserLibrary;

var stepHoot = new StepHoot();

var user = new User
{
    Name = "Ali",
    Surname = "Veliyev",
    Phone = "0513379420",
    Login = "vlikaa",
    Password = "Interpretation_1"
};

Console.WriteLine($"Имя: {UserHelper.IsCorrectName(user)}");
Console.WriteLine($"Фамилия: {UserHelper.IsCorrectSurname(user)}");
Console.WriteLine($"Номер: {UserHelper.IsCorrectPhone(user)}");
Console.WriteLine($"Логин: {UserHelper.IsCorrectLogin(user)}");
Console.WriteLine($"Пароль: {UserHelper.IsCorrectPassword(user)}");
Console.WriteLine($"Юзер: {UserHelper.IsCorrectUser(user)}");

try
{
    stepHoot.Registration(user);
}
catch (ArgumentNullException e)
{
    Console.WriteLine("привет, ты передал NULL");
}
catch (InvalidOperationException e)
{
    Console.WriteLine("привет, такой логин уже есть, поменяй его");
}
catch (ArgumentException e)
{
    Console.WriteLine("привет, твой юзер инвалид");
}

try
{
    var correctUser = stepHoot.Login(user);

    Console.WriteLine(correctUser!.Login);
}
catch (ArgumentNullException e)
{
    Console.WriteLine("привет, ты передал NULL");
}
