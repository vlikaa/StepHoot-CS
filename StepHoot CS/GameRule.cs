using System.Reflection.Metadata;
using UserLibrary;

namespace StepHoot_C_;

public static class GameRule
{
    private static readonly string _path = "users.json";
    public static void Start(StepHoot stepHoot)
    {
        User? correctUser = null;

        try
        {
            if (!File.Exists(_path))
                File.Create(_path).Close();
            if (File.ReadAllLines(_path).Length == 0)
                stepHoot.Registration(CLI.PrintRegistrationMenu());
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
                        var flagUsersSettingMenu = true;
                        // циклы нужны только чтоб не возвращаться в главное меню, а остаться в текущем
                        while (flagUsersSettingMenu)
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
                                    flagUsersSettingMenu = false;
                                    break;
                            }
                        }
                        break;
                    case 2:
                        var flagTestsSettingMenu = true;
                        while (flagTestsSettingMenu)
                        {
                            switch (CLI.PrintTestsSettingMenu())
                            {
                                case 1:
                                    var flagTestCategoriesMenu = true;
                                    while (flagTestCategoriesMenu)
                                    {
                                        switch (CLI.PrintTestCategoriesMenu())
                                        {
                                            case 1:
                                                stepHoot.AddTestCategory(CLI.PrintAddTestCategory());
                                                break;
                                            case 2:
                                                stepHoot.RemoveTestCategory(CLI.PrintSelectTestCategoryMenu());
                                                break;
                                            default:
                                                flagTestCategoriesMenu = false;
                                                break;
                                        }
                                    }
                                    break;
                                case 2:
                                    var flagTestsMenu = true;
                                    while (flagTestsMenu)
                                    {
                                        switch (CLI.PrintTestsMenu())
                                        {
                                            case 1:
                                                stepHoot.AddTest(CLI.PrintSelectTestCategoryMenu(), CLI.PrintAddTest());
                                                break;
                                            case 2:
                                                var correctCategory = CLI.PrintSelectTestCategoryMenu();
                                                stepHoot.RemoveTest(correctCategory, CLI.PrintSelectTestMenu(correctCategory));
                                                break;
                                            default:
                                                flagTestsMenu = false;
                                                break;
                                        }
                                    }
                                    break;
                                case 3:
                                    var flagQuestionMenu = true;
                                    while (flagQuestionMenu)
                                    {
                                        switch (CLI.PrintQuestionsMenu())
                                        {
                                            case 1:
                                                var correctCategory = CLI.PrintSelectTestCategoryMenu(); 
                                                stepHoot.AddQuestion(correctCategory, CLI.PrintSelectTestMenu(correctCategory), CLI.PrintAddQuestion());
                                                break;
                                            case 2:
                                                correctCategory = CLI.PrintSelectTestCategoryMenu();
                                                var correctTest = CLI.PrintSelectTestMenu(correctCategory);
                                                stepHoot.RemoveQuestion(correctCategory, correctTest, CLI.PrintSelectQuestionMenu(correctTest));
                                                break;
                                            default:
                                                flagQuestionMenu = false;
                                                break;
                                        }
                                    }
                                    break;
                                case 4:
                                    var flagAnswerMenu = true;
                                    while (flagAnswerMenu)
                                    {
                                        switch (CLI.PrintAnswersMenu())
                                        {
                                            case 1:
                                                var correctCategory = CLI.PrintSelectTestCategoryMenu(); 
                                                var correctTest = CLI.PrintSelectTestMenu(correctCategory); 
                                                stepHoot.AddAnswer(correctCategory, correctTest, CLI.PrintSelectQuestionMenu(correctTest), CLI.PrintAddAnswer());
                                                break;
                                            case 2:
                                                correctCategory = CLI.PrintSelectTestCategoryMenu();
                                                correctTest = CLI.PrintSelectTestMenu(correctCategory);
                                                var correctQuestion = CLI.PrintSelectQuestionMenu(correctTest);
                                                stepHoot.RemoveAnswer(correctCategory, correctTest, correctQuestion, CLI.PrintSelectAnswerMenu(correctQuestion));
                                                break;
                                            default:
                                                flagAnswerMenu = false;
                                                break;
                                        }
                                    }
                                    break;
                                default:
                                    flagTestsSettingMenu = false;
                                    break;
                            }
                        }

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
                        var category = CLI.PrintSelectTestCategoryMenu();
                        var test = CLI.PrintSelectTestMenu(category);
                        var grade = CLI.PrintTest(test);
                        TestStatistics.RecordTestResult(correctUser, test, grade);
                        Console.ReadLine();
                        break;
                    case 2:
                        break;
                }
            }
        }
    }
}