namespace TestLibrary;

public class Test
{
    public string TestName { get; set; } = string.Empty;
    public List<Question> Questions { get; set; } = new();


    public void AddQuestion(Question question)
    {
        Questions.Add(question);
    }
    
    public void RemoveQuestion(Question question)
    {
        Questions.Remove(question);
    }
}