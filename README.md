# Rope
__A micro .NET Framework Library to handle external keybinds using Threads__

## Example
### Declaring an single handler
```cs
KeyBindHandler singleHandler = new KeyBindHandler(Keys.R, CheckModes.PRESSED, isBackground: true, delay: 50);
```
### Declaring a multi handler
```cs
KeyBindHandler multiHandler = new KeyBindHandler(new List<Keys> {Keys.R, Keys.O, Keys.P, Keys.E }, CheckModes.PRESSED, isBackground: true, delay: 50);
```
### To start a handler
```cs
singleHandler.Start();
multiHandler.Start();
```

### Example usage
```cs
while (true)
{
    if (singleHandler.GetBindState())
    {
        Console.WriteLine("singleHandler toggled");
    }
    else if (multiHandler.GetBindState())
    {
        Console.WriteLine("multiHandler toggled");
    }
    Thread.Sleep(50);
}

```

