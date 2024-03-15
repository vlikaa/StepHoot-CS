using System.Text.Json;
using TestLibrary;
using UserLibrary;

namespace StepHoot_C_;

// Command Line Interface
public static class CLI
{
    public static User PrintRegistrationMenu()
    {
        var user = new User();
        
        Console.Clear();
        
        Console.Write("\tEnter name: ");
        user.Name = Console.ReadLine()!;
        if (string.IsNullOrEmpty(user.Name))
            throw new InvalidOperationException("User.Name is null or empty");
            
            
        Console.Write("\tEnter surname: " );
        user.Surname = Console.ReadLine() ?? throw new InvalidOperationException("User.Surname is null or empty");
        
        Console.Write("\tEnter phone number: ");
        user.Phone = Console.ReadLine() ?? throw new InvalidOperationException("User.Phone is null or empty");
        
        Console.Write("\tEnter login: ");
        user.Login = Console.ReadLine() ?? throw new InvalidOperationException("User.Login is null or empty");
        
        Console.Write("\tEnter password: ");
        user.Password = Console.ReadLine() ?? throw new InvalidOperationException("User.Password is null or empty");
        
        return user;
    }

    public static User PrintLoginMenu()
    {
        var user = new User();

        Console.Clear();
        
        Console.Write("\tEnter login: ");
        user.Login = Console.ReadLine() ?? throw new InvalidOperationException("User.Login is null or empty");
        
        Console.Write("\tEnter password: ");
        user.Password = Console.ReadLine() ?? throw new InvalidOperationException("User.Password is null or empty");
        
        return user;
    }

    public static int PrintAdminMenu()
    {
        Console.Clear();
        
        Console.WriteLine("    Admin menu:" +
                          "\n\t1. Users settings" +
                          "\n\t2. Tests settings" +
                          "\n\t3. Check stats" +
                          "\n\t0. Logout");
        
        return int.Parse(Console.ReadLine()!);
    }

    public static int PrintUserMenu()
    {
        Console.Clear();
        
        Console.WriteLine("    Menu:" +
                          "\n\t1. Pass test" +
                          "\n\t2. Previous test results" +
                          "\n\t0. Logout");
        
        return int.Parse(Console.ReadLine()!);
    }
    
    public static int PrintUsersSettingMenu()
    {
        Console.Clear();
        
        Console.WriteLine("    Users setting:" +
                          "\n\t1. Add user" +
                          "\n\t2. Remove user" +
                          "\n\t3. Change data" +
                          "\n\t0. Back");
        
        return int.Parse(Console.ReadLine()!);
    }
    
    public static int PrintTestsSettingMenu()
    {
        Console.Clear();
        
        Console.WriteLine("    Tests setting:" +
                          "\n\t1. Categories setting" +
                          "\n\t2. Tests setting" +
                          "\n\t3. Questions setting" +
                          "\n\t4. Answer setting" +
                          "\n\t0. Back");
        
        return int.Parse(Console.ReadLine()!);
    }
    
    public static int PrintStatMenu()
    {
        Console.Clear();
        
        Console.WriteLine("    Statistics menu:" +
                          "\n\t1. Show full stat" +
                          "\n\t2. Show stat by category" +
                          "\n\t0. Back");
        
        return int.Parse(Console.ReadLine()!);
    }
    
    public static User PrintSelectUserMenu()
    {
        var users = File.ReadAllLines(StepHoot.UsersPath);
        
        if (users.Length <= 1)
            throw new InvalidOperationException("\n    Users list is empty.");
        
        var index = 0;
        
        Console.Clear();
        Console.WriteLine("    Select user:");
        foreach (var userStr in File.ReadAllLines(StepHoot.UsersPath).Skip(1))
        {
            Console.WriteLine($"{++index}. {JsonSerializer.Deserialize<User>(userStr)?.Login}");
        }

        return StepHoot.GetUserByIndex(int.Parse(Console.ReadLine()!))!;
    }
    
    public static int PrintChangeUserDataMenu()
    {
        Console.Clear();
        
        Console.WriteLine("    Change user data menu:" +
                          "\n\t1. Change name" +
                          "\n\t2. Change surname" +
                          "\n\t3. Change phone number" +
                          "\n\t4. Change login" +
                          "\n\t5. Change password" +
                          "\n\t0. Back");
        
        return int.Parse(Console.ReadLine()!);
    }

    public static string PrintChangeUserName()
    {
        Console.Clear();
        
        Console.Write("\tEnter new name: ");
        
        return Console.ReadLine()!;
    }

    public static string PrintChangeUserSurname()
    {
        Console.Clear();
        
        Console.Write("\tEnter new surname: ");
        
        return Console.ReadLine()!;
    }

    public static string PrintChangeUserPhone()
    {
        Console.Clear();
        
        Console.Write("\tEnter new phone number: ");
        
        return Console.ReadLine()!;
    }

    public static string PrintChangeUserLogin()
    {
        Console.Clear();
        
        Console.Write("\tEnter new login: ");
        
        return Console.ReadLine()!;
    }

    public static string PrintChangeUserPassword()
    {
        Console.Clear();
        
        Console.Write("\tEnter new password: ");
        
        return Console.ReadLine()!;
    }

    public static int PrintTestCategoriesMenu()
    {
        Console.Clear();
        
        Console.WriteLine("    Test categories setting:" +
                          "\n\t1. Add test category" +
                          "\n\t2. Remove test category" +
                          "\n\t0. Back");
        
        return int.Parse(Console.ReadLine()!);
    }
    
    public static TestCategory PrintAddTestCategory()
    {
        Console.Clear();

        Console.Write("\tEnter category name: ");

        var testCategory = new TestCategory
        {
            TestCategoryName = Console.ReadLine()! 
        };

        return testCategory;
    }

    public static TestCategory PrintSelectTestCategoryMenu()
    {
        var lines = File.ReadAllLines(StepHoot.TestsPath);
        
        if (lines.Length < 1)
            throw new InvalidOperationException("\n    Test categories list is empty.");

        var index = 0;
        
        Console.Clear();
        Console.WriteLine("    Select category:");
        foreach (var line in lines)
        {
            Console.WriteLine($"{++index}. {JsonSerializer.Deserialize<TestCategory>(line)?.TestCategoryName}");
        }
        
        return StepHoot.GetTestCategoryByIndex(int.Parse(Console.ReadLine()!) - 1)!;
    }

    public static int PrintTestsMenu()
    {
        Console.Clear();
        
        Console.WriteLine("    Tests setting:" +
                          "\n\t1. Add test" +
                          "\n\t2. Remove test" +
                          "\n\t0. Back");
        
        return int.Parse(Console.ReadLine()!);
    }
    
    public static Test PrintAddTest()
    {
        Console.Clear();

        Console.Write("\tEnter test name: ");

        var test = new Test
        {
            TestName = Console.ReadLine()! 
        };

        return test;
    }

    public static Test PrintSelectTestMenu(TestCategory testCategory)
    {
        var tests = testCategory.Tests;
        
        if (tests.Count < 1)
            throw new InvalidOperationException("\n    Tests list is empty.");
        
        var index = 0;
        
        Console.Clear();
        Console.WriteLine("    Select test:");
        foreach (var test in tests)
        {
            Console.WriteLine($"{++index}. {test.TestName}");
        }
        
        return StepHoot.GetTestByIndex(testCategory, int.Parse(Console.ReadLine()!) - 1)!;
    }
}
