namespace TestLibrary;

class Question : IQuestion
{
    string IQuestion.Question { get; set; } = string.Empty;
    private readonly List<Answer> _answers = new();
    
    public void AddAnswer(Answer? answer)
    {
        if (answer != null)
        {
            Console.WriteLine(answer.IsCorrect);
            _answers.Add(answer);
        }
        
        
        throw new NotImplementedException();
    }

    public void RemoveAnswer(Answer answer)
    {
        throw new NotImplementedException();
    }
}