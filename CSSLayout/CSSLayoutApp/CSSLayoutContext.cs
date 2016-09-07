namespace CSSLayoutApp
{
    public class CSSLayoutContext
    {
        public MeasureOutput MeasureOutput { get; } = new MeasureOutput();
        int CurrentGenerationCount { get; set; }
    }
}
