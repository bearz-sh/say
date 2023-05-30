// See https://aka.ms/new-console-template for more information
using Bearz.Say.Core;

var phrase = args.SingleOrDefault() ?? "Hello World!";

var bear = BearzTamer.Default.TameBear("bearface");
Console.WriteLine(bear.Say(phrase));