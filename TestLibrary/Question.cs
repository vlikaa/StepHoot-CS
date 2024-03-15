namespace TestLibrary;

public class Question
{
    public string QuestionName { get; set; } = string.Empty;
    private readonly List<Answer> _answers = new(); 
    
    public void AddAnswer(Answer answer)
    {
        _answers.Add(answer);
    }

    public void RemoveAnswer(Answer answer)
    {
        _answers.Remove(answer);
    }
}