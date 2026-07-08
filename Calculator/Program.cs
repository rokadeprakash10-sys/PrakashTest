using PrakashTest.Calculator;

var calc = new Calculator();

Console.WriteLine("=== PrakashTest Calculator ===");
Console.WriteLine("Operations: +  -  *  /  %");
Console.WriteLine("Type 'exit' to quit.");
Console.WriteLine();

while (true)
{
    Console.Write("Enter expression (e.g. 10 + 5): ");
    var input = Console.ReadLine()?.Trim();

    if (string.IsNullOrEmpty(input) || input.Equals("exit", StringComparison.OrdinalIgnoreCase))
        break;

    var parts = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
    if (parts.Length != 3 ||
        !double.TryParse(parts[0], out var left) ||
        !double.TryParse(parts[2], out var right))
    {
        Console.WriteLine("Invalid format. Use: <number> <op> <number>");
        continue;
    }

    try
    {
        var result = parts[1] switch
        {
            "+" => calc.Add(left, right),
            "-" => calc.Subtract(left, right),
            "*" => calc.Multiply(left, right),
            "/" => calc.Divide(left, right),
            "%" => calc.Modulo(left, right),
            _   => throw new NotSupportedException($"Unknown operator: {parts[1]}")
        };
        Console.WriteLine($"  = {result}");
    }
    catch (Exception ex)
    {
        Console.WriteLine($"  Error: {ex.Message}");
    }

    Console.WriteLine();
}
