namespace WebApplicationTest;

public class TextObject
{
    public int Index { get; set; } 
    public string Text { get; set; }
    public string BackColor { get; set; }
    public string ForeColor { get; set; }

    public TextObject(int index, string text, string backColor, string foreColor)
    {
        Index = index;
        Text = text;
        BackColor = backColor;
        ForeColor = foreColor;
    }
}