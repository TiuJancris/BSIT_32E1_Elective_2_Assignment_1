namespace AssignmentApp.Models;

public class QuestionAnswer
{
    public int Number { get; set; }
    public string Question { get; set; } = string.Empty;
    public string Options { get; set; } = string.Empty;
    public string Answer { get; set; } = string.Empty;
    public string AnswerText { get; set; } = string.Empty;
    public string Explanation { get; set; } = string.Empty;
    public string Topic { get; set; } = string.Empty;
}
