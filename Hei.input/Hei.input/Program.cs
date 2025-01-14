
Run();

void Run(){
    Console.WriteLine("Hei, hva heter du?");
    var input = Console.ReadLine();
    Console.WriteLine($"Velkommen, {input}");
    Console.WriteLine("Hvor gammel er du?");
    var inputAge = Console.ReadLine();
    Console.WriteLine($"{inputAge}, en fin alder");
}