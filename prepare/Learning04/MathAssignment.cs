public class MathAssignment : Assignment
{
    private string _textbookSelection;
    private string _problems;

    public MathAssignment(string studentName, string topic, string textbookSelection, string problems)
        : base(studentName, topic)
    {
        _textbookSelection = textbookSelection;
        _problems = problems;
    }

    public string GetHomeWorkList()
    {
        return $"Selection {_textbookSelection} Problems {_problems}";
    }
}