using System.Text.Json;
using UserLibrary;

namespace StepHoot_C_;

class StepHoot : IStepHoot
{
    private readonly string _path = "users.json"; 
    
    public bool Registration(User? user)
    {
        if (user == null)
            return false;

        if (IsRepeatUser(user))
            return false;
        
        if (!UserHelper.IsCorrectUser(user))
            return false;
        
        File.AppendAllText(_path, JsonSerializer.Serialize(user) + '\n');
        
        return true;
    }

    public bool Login(User? user)
    {
        return true;
    }

    private bool IsRepeatUser(User? user)
    {
        return true;
    }
    
}