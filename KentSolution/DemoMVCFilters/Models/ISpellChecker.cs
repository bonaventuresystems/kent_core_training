namespace DemoMVCFilters.Models
{
    public interface ISpellChecker
    {
        void CheckSpelling(string text);
    }

    public class EnglishSpellChecker : ISpellChecker
    {
        public EnglishSpellChecker()
        {
            
        }
        public void CheckSpelling(string text)
        {
            // Dummy implementation for demonstration
            Console.WriteLine($"Checking spelling for: {text}");
        }
    }
    public class HindiSpellChecker : ISpellChecker
    {
        public HindiSpellChecker()
        {
            
        }
        public void CheckSpelling(string text)
        {
            // Dummy implementation for demonstration
            Console.WriteLine($"Checking spelling for: {text}");
        }   
    }


}
