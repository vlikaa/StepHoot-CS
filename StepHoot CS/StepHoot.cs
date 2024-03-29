using System.Text.Json;
using UserLibrary;
using TestLibrary;

namespace StepHoot_C_;

public class StepHoot
{
    public static readonly string UsersPath = "users.json"; 
    public static readonly string TestsPath = "tests.json"; 
    
    public void Registration(User? user)
    {
        if (user == null)
            throw new ArgumentNullException($"User is null");

        if (GetUser(user) != null)
            throw new InvalidOperationException("User must be unique");

        if (!UserHelper.IsCorrectUser(user))
            throw new ArgumentException("Invalid User");

        if (File.ReadAllLines(UsersPath).Length == 0)
            user.IsAdmin = true;
            
        if (!File.Exists(UsersPath))
            File.Create(UsersPath).Close();
        
        File.AppendAllText(UsersPath, JsonSerializer.Serialize(user) + '\n');
    }

    public User? Login(User? user)
    {
        if (user == null)
            throw new ArgumentNullException($"User is null");

        var correctUser = GetUser(user);

        return correctUser?.Password == user.Password ? correctUser : null;
    }

    public void RemoveUser(User? user)
    {
        if (user == null)
            throw new ArgumentNullException($"User is null");

        var usersStr = File.ReadAllLines(UsersPath);
        var users = new List<string>();
        
        foreach (var userStr in usersStr)
        {
            var deserializedUser = JsonSerializer.Deserialize<User>(userStr);

            if (user.Login != deserializedUser?.Login)
                users.Add(userStr); 
        }

        File.WriteAllLines(UsersPath, users.ToArray());
    }
    
    public static User? GetUserByIndex(int index)
    {
        var users = File.ReadAllLines(UsersPath);

        if (index < 0 || index > users.Length + 1)
            throw new IndexOutOfRangeException("Incorrect index.");

        var correctIndex = 0;
        
        foreach (var user in users)
        {
            if (index == correctIndex)
                return JsonSerializer.Deserialize<User>(user);
            
            ++correctIndex;
        }

        return null;
    }
    public static TestCategory? GetTestCategoryByIndex(int index)
    {
        var categories = File.ReadAllLines(TestsPath);

        if (index < 0 || index > categories.Length + 1)
            throw new IndexOutOfRangeException("Incorrect index.");

        var correctIndex = 0;
        
        foreach (var category in categories)
        {
            if (index == correctIndex)
                return JsonSerializer.Deserialize<TestCategory>(category);
            
            ++correctIndex;
        }

        return null;
    }
    public static Test? GetTestByIndex(TestCategory category, int index)
    {
        var tests = category.Tests;
        
        if (index < 0 || index > tests.Count + 1)
            throw new IndexOutOfRangeException("Incorrect index.");

        var correctIndex = 0;
        
        foreach (var test in tests)
        {
            if (index == correctIndex)
                return test;
            
            ++correctIndex;
        }

        return null;
    }
    public static Question? GetQuestionByIndex(Test test, int index)
    {
        var questions = test.Questions;
        
        if (index < 0 || index > questions.Count + 1)
            throw new IndexOutOfRangeException("Incorrect index.");

        var correctIndex = 0;
        
        foreach (var question in questions)
        {
            if (index == correctIndex)
                return question;
            
            ++correctIndex;
        }

        return null;
    }
    public static Answer? GetAnswerByIndex(Question question, int index)
    {
        var answers = question.Answers;
        
        if (index < 0 || index > answers.Count + 1)
            throw new IndexOutOfRangeException("Incorrect index.");

        var correctIndex = 0;
        
        foreach (var answer in answers)
        {
            if (index == correctIndex)
                return answer;
            
            ++correctIndex;
        }

        return null;
    }
    

    public void ChangeUserName(User user, string name)
    {
        // Нашел такой прикол в исходном коде,
        // до этого использовал проверку на string.IsNullOrEmpty();
        ArgumentException.ThrowIfNullOrEmpty(name, "Name is null or empty");

        if (!UserHelper.IsCorrectName(name))
            throw new InvalidOperationException("Incorrect name for user.");
        
        var lines = File.ReadAllLines(UsersPath);
        var users = new List<User>();
        
        foreach (var line in lines)
        {
            var deserializedUser = JsonSerializer.Deserialize<User>(line);
            if (deserializedUser == null) continue;
            if (user.Login == deserializedUser.Login)
                deserializedUser.Name = name;

            users.Add(deserializedUser);
        }

        File.WriteAllLines(UsersPath, users.Select(u => JsonSerializer.Serialize(u)).ToArray());
    }
    public void ChangeUserSurname(User user, string surname)
    {
        if (string.IsNullOrEmpty(surname))
            throw new ArgumentNullException($"Surname is null or empty.");

        if (!UserHelper.IsCorrectSurname(surname))
            throw new InvalidOperationException("Incorrect surname for user.");

        
        var lines = File.ReadAllLines(UsersPath);
        var users = new List<User>();
        
        foreach (var line in lines)
        {
            var deserializedUser = JsonSerializer.Deserialize<User>(line);
            if (deserializedUser == null) continue;
            if (user.Login == deserializedUser.Login)
                deserializedUser.Surname = surname;

            users.Add(deserializedUser);
        }

        File.WriteAllLines(UsersPath, users.Select(u => JsonSerializer.Serialize(u)).ToArray());
    }
    public void ChangeUserPhone(User user, string phone)
    {
        if (string.IsNullOrEmpty(phone))
            throw new ArgumentNullException($"Phone number is null or empty.");
        
        if (!UserHelper.IsCorrectPhone(phone))
            throw new InvalidOperationException("Incorrect phone number for user.");

        var lines = File.ReadAllLines(UsersPath);
        var users = new List<User>();
        
        foreach (var line in lines)
        {
            var deserializedUser = JsonSerializer.Deserialize<User>(line);
            if (deserializedUser == null) continue;
            if (user.Login == deserializedUser.Login)
                deserializedUser.Phone = phone;

            users.Add(deserializedUser);
        }

        File.WriteAllLines(UsersPath, users.Select(u => JsonSerializer.Serialize(u)).ToArray());
    }
    public void ChangeUserLogin(User user, string login)
    {
        if (string.IsNullOrEmpty(login))
            throw new ArgumentNullException($"Login is null or empty.");

        if (!UserHelper.IsCorrectLogin(login))
            throw new InvalidOperationException("Incorrect login for user.");
        
        var lines = File.ReadAllLines(UsersPath);
        var users = new List<User>();
        
        foreach (var line in lines)
        {
            var deserializedUser = JsonSerializer.Deserialize<User>(line);
            if (deserializedUser == null) continue;
            if (user.Login == deserializedUser.Login)
                deserializedUser.Login = login;

            users.Add(deserializedUser);
        }

        File.WriteAllLines(UsersPath, users.Select(u => JsonSerializer.Serialize(u)).ToArray());
    }
    public void ChangeUserPassword(User user, string password)
    {
        if (string.IsNullOrEmpty(password))
            throw new ArgumentNullException($"Password is null or empty.");
        
        var lines = File.ReadAllLines(UsersPath);
        var users = new List<User>();
        
        foreach (var line in lines)
        {
            var deserializedUser = JsonSerializer.Deserialize<User>(line);
            if (deserializedUser == null) continue;
            if (user.Login == deserializedUser.Login)
            {
                deserializedUser.Password = password;
                
                // Проверка на Correct Password находится тут, потому что метод должнен принять User-а в параметрах
                // поэтому проверка происходит после того как Password у User-a изменен
                if (!UserHelper.IsCorrectPassword(deserializedUser))
                    throw new InvalidOperationException("Incorrect password for user.");
            }

            users.Add(deserializedUser);
        }

        File.WriteAllLines(UsersPath, users.Select(u => JsonSerializer.Serialize(u)).ToArray());
    }

    public void AddTestCategory(TestCategory testCategory)
    {
        ArgumentNullException.ThrowIfNull(testCategory, "Test category is null.");
        
        if (!File.Exists(TestsPath))
            File.Create(TestsPath).Close();
        
        File.AppendAllText(TestsPath,JsonSerializer.Serialize(testCategory) + '\n');
    }
    public void AddTest(TestCategory testCategory, Test test)
    {
        ArgumentNullException.ThrowIfNull(testCategory, "Test category is null.");
        ArgumentNullException.ThrowIfNull(test, "Test is null.");
        
        testCategory.AddTest(test);

        var lines = File.ReadAllLines(TestsPath);
        var newTestCategories = new List<string>();

        foreach (var line in lines)
        {
            var deserializedCategory = JsonSerializer.Deserialize<TestCategory>(line);

            if (testCategory.TestCategoryName == deserializedCategory?.TestCategoryName)
            {
                newTestCategories.Add(JsonSerializer.Serialize(testCategory));
                continue;
            }
            
            newTestCategories.Add(line);
        }
        
        File.WriteAllLines(TestsPath, newTestCategories.ToArray());
    } 
    public void AddQuestion(TestCategory testCategory, Test test, Question question)
    {
        ArgumentNullException.ThrowIfNull(testCategory, "Test category is null.");
        ArgumentNullException.ThrowIfNull(test, "Test is null.");
        ArgumentNullException.ThrowIfNull(question, "Question is null.");
        
        var lines = File.ReadAllLines(TestsPath);
        var newTestCategories = new List<string>();

        foreach (var line in lines)
        {
            var deserializedCategory = JsonSerializer.Deserialize<TestCategory>(line);

            if (testCategory.TestCategoryName == deserializedCategory?.TestCategoryName)
            {
                foreach (var t in testCategory.Tests)
                {
                    if (test.TestName == t.TestName)
                    {
                        t.AddQuestion(question);
                        
                        newTestCategories.Add(JsonSerializer.Serialize(testCategory));
                        
                        break;
                    }
                }
                
                continue;
            }
            
            newTestCategories.Add(line);
        }
        
        File.WriteAllLines(TestsPath, newTestCategories.ToArray());
    }
    public void AddAnswer(TestCategory testCategory, Test test, Question question, Answer answer)
    {
        ArgumentNullException.ThrowIfNull(testCategory, "Test category is null.");
        ArgumentNullException.ThrowIfNull(test, "Test is null.");
        ArgumentNullException.ThrowIfNull(question, "Question is null.");
        ArgumentNullException.ThrowIfNull(answer, "Answer is null.");
        
        var lines = File.ReadAllLines(TestsPath);
        var newTestCategories = new List<string>();

        foreach (var line in lines)
        {
            var deserializedCategory = JsonSerializer.Deserialize<TestCategory>(line);

            if (testCategory.TestCategoryName == deserializedCategory?.TestCategoryName)
            {
                foreach (var t in testCategory.Tests)
                {
                    if (test.TestName == t.TestName)
                    {
                        foreach (var q in test.Questions)
                        {
                            if (question.QuestionName == q.QuestionName)
                            {
                                q.AddAnswer(answer);
                            
                                newTestCategories.Add(JsonSerializer.Serialize(testCategory));
                            
                                break;
                            }
                        }
                    }
                }
                
                continue;
            }
            
            newTestCategories.Add(line);
        }
        
        File.WriteAllLines(TestsPath, newTestCategories.ToArray());
    }

    public void RemoveTestCategory(TestCategory testCategory)
    {
        ArgumentNullException.ThrowIfNull(testCategory, $"Category is null");

        var lines = File.ReadAllLines(TestsPath);
        // LINQ метод написал Rider
        File.WriteAllLines(TestsPath, (from line in lines let deserializedUser = JsonSerializer.Deserialize<TestCategory>(line) where testCategory.TestCategoryName != deserializedUser?.TestCategoryName select line).ToArray());        
    }
    public void RemoveTest(TestCategory testCategory, Test test)
    {
        ArgumentNullException.ThrowIfNull(testCategory, $"Category is null");
        ArgumentNullException.ThrowIfNull(test, $"Test is null");

        var lines = File.ReadAllLines(TestsPath);
        var newLines = new List<string>();

        foreach (var line in lines)
        {
            if (testCategory.TestCategoryName == JsonSerializer.Deserialize<TestCategory>(line)?.TestCategoryName)
            {
                testCategory.RemoveTest(test);
                
                newLines.Add(JsonSerializer.Serialize(testCategory));
                
                continue;
            }
            
            newLines.Add(line);
        }
        
        File.WriteAllLines(TestsPath, newLines);
    }
    public void RemoveQuestion(TestCategory testCategory, Test test, Question question)
    {
        ArgumentNullException.ThrowIfNull(testCategory, $"Category is null");
        ArgumentNullException.ThrowIfNull(test, $"Test is null");
        ArgumentNullException.ThrowIfNull(question, $"Question is null");

        var lines = File.ReadAllLines(TestsPath);
        var newLines = new List<string>();

        foreach (var line in lines)
        {
            if (testCategory.TestCategoryName == JsonSerializer.Deserialize<TestCategory>(line)?.TestCategoryName)
            {
                foreach (var t in testCategory.Tests)
                {
                    if (test.TestName == t.TestName)
                    {
                        t.RemoveQuestion(question);
                        
                        newLines.Add(JsonSerializer.Serialize(testCategory));

                        break;
                    }
                }
                
                continue;
            }
            
            newLines.Add(line);
        }
        
        File.WriteAllLines(TestsPath, newLines);
    }
    public void RemoveAnswer(TestCategory testCategory, Test test, Question question, Answer answer)
    {
        ArgumentNullException.ThrowIfNull(testCategory, $"Category is null");
        ArgumentNullException.ThrowIfNull(test, $"Test is null");
        ArgumentNullException.ThrowIfNull(question, $"Question is null");
        ArgumentNullException.ThrowIfNull(answer, $"Answer is null");

        var lines = File.ReadAllLines(TestsPath);
        var newLines = new List<string>();

        foreach (var line in lines)
        {
            if (testCategory.TestCategoryName == JsonSerializer.Deserialize<TestCategory>(line)?.TestCategoryName)
            {
                foreach (var t in testCategory.Tests)
                {
                    if (test.TestName == t.TestName)
                    {
                        foreach (var q in test.Questions)
                        {
                            if (question.QuestionName == q.QuestionName)
                            {
                                q.RemoveAnswer(answer);
                                
                                newLines.Add(JsonSerializer.Serialize(testCategory));

                                break;
                            }
                        }
                    }
                }
                
                continue;
            }
            
            newLines.Add(line);
        }
        
        File.WriteAllLines(TestsPath, newLines);
    }
    
    private User? GetUser(User user)
    {
        var usersStr = File.ReadAllLines(UsersPath);

        // Generated by Rider, Гы
        // LINQ метод сначала преобразует каждый элемент usersStr в User,
        // затем фильтрует псевдо-коллекцию чтоб были только User-ы, ибо Deserialize может вернуть null,
        // далее FirstOrDefault ищет User-a, всё :)
        return usersStr.Select(userStr =>
            JsonSerializer.Deserialize<User>(userStr)).OfType<User>().FirstOrDefault(deserializedUser =>
            user.Login == deserializedUser.Login);
    }
}
