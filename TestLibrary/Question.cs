namespace TestLibrary;

public class Question
{
    public string QuestionName { get; set; } = string.Empty;
    public List<Answer> Answers { get; set; } = new();

    public void AddAnswer(Answer answer)
    {
        Answers.Add(answer);
    }

    public void RemoveAnswer(Answer answer)
    {
        Answers.Remove(answer);
    }
}