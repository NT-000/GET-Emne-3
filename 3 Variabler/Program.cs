int a = 5;
decimal b = 3m;
Console.WriteLine("What's the most precise variable to use for sum - int or decimal?");
var input = Console.ReadLine();
Console.WriteLine(input == "decimal" ? "Correct" : "Wrong, decimal is correct variable to use here");

decimal sum = a + b;
Console.WriteLine($"Int: {a} and decimal: {b}, a+b equals {sum}");
