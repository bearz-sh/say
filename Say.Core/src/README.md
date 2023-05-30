# Bearz.Say.Core

## Description

Extends the Cowsay library with synchronous methods.

## Features

- [X] Extends the Cowsay library synchronous methods.
- [ ] Scan text and change the eyes for the bearz, cows.
- [ ] Add additional bear ascii art.

### Example

```csharp
using Bearz.Say.Core;

var phrase = args.SingleOrDefault() ?? "Hello World!";

var bear = BearzTamer.Default.TameBear("bearface");
Console.WriteLine(bear.Say(phrase));
```

## License

MIT
