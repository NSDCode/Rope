# Rope
_ _A micro .NET Framework Lirbary to handle external keybinds using Threads_ _

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
      Console.WriteLine("singleHandler toggled")
  } else if (mutltiHandler.GetBindState())
  {
      Console.WriteLine("multiHandler toggled");
  }
  Thread.Sleep(50)
}
```

