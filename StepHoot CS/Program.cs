
// TODO: допиши GetUserByIndex
// TODO: допиши GetUserByIndex
// TODO: допиши GetUserByIndex


using System.Security.Cryptography;
using StepHoot_C_;
using UserLibrary;

var stepHoot = new StepHoot();
User? correctUser = null;

try
{
    // stepHoot.Registration(CLI.PrintRegistrationMenu());
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
    correctUser = stepHoot.Login(CLI.PrintLoginMenu());
}
catch (ArgumentNullException e)
{
    Console.WriteLine("привет, ты передал NULL");
}


while (true)
{
    if (correctUser!.IsAdmin)
    {
        switch (CLI.PrintAdminMenu())
        {
            case 0:
                correctUser = stepHoot.Login(CLI.PrintLoginMenu());
                break;
            case 1:
                switch (CLI.PrintUsersSettingMenu())
                {
                    case 1:
                        stepHoot.Registration(CLI.PrintRegistrationMenu());
                        break;
                    case 2:
                        // stepHoot.RemoveUser(CLI.PrintRemoveMenu());
                        break;
                }
                break;
            case 2:
                CLI.PrintTestsSettingMenu();
                break;
            case 3:
                CLI.PrintStatMenu();
                break;

        }
    }
    else
    {
        switch (CLI.PrintUserMenu())
        {
            case 0:
                correctUser = stepHoot.Login(CLI.PrintLoginMenu());
                break;
            case 1:
                break;
            case 2:
                break;
        }
    }
}