using TestLibrary;
using UserLibrary;

namespace StepHoot_C_;

public static class TestStatistics
{
    private static Dictionary<User, Dictionary<Test, int>> _userTestScores = new();

    public static void RecordTestResult(User user, Test test, int score)
    {
        if (!_userTestScores.ContainsKey(user))
        {
            _userTestScores[user] = new Dictionary<Test, int>();
        }

        _userTestScores[user][test] = score;
    }

    public static double GetUserAverageScore(User user)
    {
        if (!_userTestScores.ContainsKey(user))
        {
            Console.WriteLine($"User {user.Login} has not found.");
            return 0;
        }

        var totalScore = 0;
        
        foreach (var testScore in _userTestScores[user].Values)
        {
            totalScore += testScore;
        }

        return totalScore / _userTestScores[user].Count;
    }

    public static double GetSystemAverageScore()
    {
        if (_userTestScores.Count == 0)
        {
            Console.WriteLine("List of the test is empty.");
            return 0;
        }

        double totalScore = 0;
        int totalTests = 0;
        foreach (var userScores in _userTestScores.Values)
        {
            foreach (var score in userScores.Values)
            {
                totalScore += score;
                totalTests++;
            }
        }

        return totalScore / totalTests;
    }
}
