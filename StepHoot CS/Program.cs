
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
                var flagUserSettingsMenu = true;
                // циклы нужны только чтоб не возвращаться в главное меню, а остаться в текущем
                while (flagUserSettingsMenu)
                {
                    switch (CLI.PrintUsersSettingMenu())
                    {
                        case 1:
                            stepHoot.Registration(CLI.PrintRegistrationMenu());
                            break;
                        case 2:
                            try
                            {
                                stepHoot.RemoveUser(CLI.PrintSelectUserMenu());
                            }
                            catch (InvalidOperationException e)
                            {
                                Console.Clear();
                                Console.WriteLine(e.Message);
                                Console.ReadKey();
                            }
                            break;
                        case 3:
                            var flagChangeUserDataMenu = true;
                            while (flagChangeUserDataMenu)
                            {
                                switch (CLI.PrintChangeUserDataMenu())
                                {
                                    case 1:
                                        stepHoot.ChangeUserName(CLI.PrintSelectUserMenu(), CLI.PrintChangeUserName());
                                        break;
                                    case 2:
                                        stepHoot.ChangeUserSurname(CLI.PrintSelectUserMenu(), CLI.PrintChangeUserSurname());
                                        break;
                                    case 3:
                                        stepHoot.ChangeUserPhone(CLI.PrintSelectUserMenu(), CLI.PrintChangeUserPhone());
                                        break;
                                    case 4:
                                        stepHoot.ChangeUserLogin(CLI.PrintSelectUserMenu(), CLI.PrintChangeUserLogin());
                                        break;
                                    case 5:
                                        stepHoot.ChangeUserPassword(CLI.PrintSelectUserMenu(), CLI.PrintChangeUserPassword());
                                        break;
                                    default:
                                        flagChangeUserDataMenu = false;
                                        break;
                                }
                            }
                            break;
                        default:
                            flagUserSettingsMenu = false;
                            break;
                    }
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