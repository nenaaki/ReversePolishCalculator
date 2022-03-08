using System.Globalization;

namespace Calculator
{
    [AttributeUsage(AttributeTargets.Method)]
    public class CommandAttribute : Attribute
    {
        private readonly string Name;

        public string Description;

        public CommandAttribute(string name)
        {
            Name = name;
            Description = "";
        }

        public string[] GetCallName()
            => new string[]
            {
                Name,
                CultureInfo.CurrentCulture.TextInfo.ToTitleCase(Name)
            };
    }
}