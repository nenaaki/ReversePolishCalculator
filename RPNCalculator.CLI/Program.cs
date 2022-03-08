using System.Reflection;
using Calculator;

// See https://aka.ms/new-console-template for more information
Console.WriteLine("RPN Calculator (Preview)");

var calculator = new Calculator.Calculator();

var commands = new Dictionary<string, Action>();

commands["exit"] = () => { calculator = null; };
commands["quit"] = () => { calculator = null; };
commands["help"] = () => { Console.WriteLine(string.Join(", ", commands.Keys)); };


while (calculator is not null)
{
    var methods = calculator.GetType().GetMethods().Where(each => each.GetCustomAttribute<CommandAttribute>() is not null && each.Name != "Push");
    foreach(var method in methods)
    {
        commands[method.Name.ToLower()] = () => method.Invoke(calculator, null);
    }

    var stack = calculator.DisplayStack();
    Console.WriteLine(stack);

    Console.Write(">");

    var input = Console.ReadLine();

    if (input == null) continue;

    try
    {
        if (commands.TryGetValue(input.ToLower(), out var command))
        {
            command();
            continue;
        }

        calculator.Push(input);
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
    }
}