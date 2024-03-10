
namespace TestLibrary;

public interface IQuestion
{
    string Question { get; set; }
    void AddAnswer(Answer answer);
    void RemoveAnswer(Answer answer);
}