namespace TestLibrary;

public class Test
{
    public string TestName { get; set; } = string.Empty;
    private readonly List<Question> _questions = new();

    public void AddQuestion(Question question)
    {
        _questions.Add(question);
    }
    
    public void RemoveQuestion(Question question)
    {
        _questions.Remove(question);
    }
}