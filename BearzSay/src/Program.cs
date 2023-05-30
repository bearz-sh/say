// See https://aka.ms/new-console-template for more information
using Cowsay;

var cow = await DefaultCattleFarmer.RearCowWithDefaults("bearface");
Console.WriteLine(cow.Say("Hello World!"));