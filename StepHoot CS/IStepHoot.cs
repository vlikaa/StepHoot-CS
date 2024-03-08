using UserLibrary;

namespace StepHoot_C_;

interface IStepHoot
{
    bool Registration(User? user);
    bool Login(User? user);
}