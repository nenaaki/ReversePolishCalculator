namespace Calculator.RPNComponents.FlowControl
{
    internal class End : FlowControlBase<End>
    {
        public override string Name => ";";

        public override void Execute(IRPNStack calculationTargets) { }
    }
}
