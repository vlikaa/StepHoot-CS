namespace TestLibrary;

public class Answer : IAnswer
{
    string IAnswer.Answer { get; set; } = string.Empty;
    public bool IsCorrect { get; set; } = default;
}