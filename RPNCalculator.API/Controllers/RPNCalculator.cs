using Microsoft.AspNetCore.Mvc;
using Calculator;

namespace RPNCalculator.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RPNCalculator : ControllerBase
    {
        private readonly ICalculator calculator;

        public RPNCalculator(ICalculator calculator) => this.calculator = calculator;

        [HttpGet(Name = "AllCommand")]
        public IEnumerable<string> GetAllCommand()
            => calculator.GetAllCommand().Split("\n");

        [HttpPost("CommandExecution")]
        public string? PostCommandExecution(Command command)
        {
            var result = calculator.CallCommand(command.Name, null);
            return (result is null) ? "" : result.ToString();
        }

        [HttpPost("FormulaPush")]
        public string PostFormulaPush(PushCommand pushCommand)
        {
            calculator.Push(pushCommand.Formula);
            return calculator.DisplayStack();
        }
    }

    public class Command
    {
        public string Name { get; set; } = "";
    }

    public class PushCommand
    {
        public string Formula { get; set; } = "";
    }
}