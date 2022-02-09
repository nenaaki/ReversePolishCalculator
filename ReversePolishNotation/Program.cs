// サンプル

var tesutoString = "5 6 * 3 +";

var calculator = new Calculator.Calculator(tesutoString);

while (calculator.DoCalc()) { }
calculator.DisplayStack();