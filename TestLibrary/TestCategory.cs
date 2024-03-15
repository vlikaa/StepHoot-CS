namespace TestLibrary;

public class TestCategory
{
    public string TestCategoryName { get; set; } = string.Empty;
    public List<Test> Tests { get; set; } = new();

    public void AddTest(Test test)
    {
        Tests.Add(test);
    }
    
    public void RemoveTest(Test test)
    {
        Tests.Remove(test);
    }

}