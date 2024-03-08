using UserLibrary;

namespace StepHoot_C_;

interface IStepHoot
{
    void Registration(User? user);
    User? Login(User? user);
}