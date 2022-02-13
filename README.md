# Rope
_ _A micro .NET Framework Lirbary to handle external keybinds using Threads_ _

## Example
```cs
KeyBindHandler singleHandler = new KeyBindHandler(Keys.R, CheckModes.PRESSED, isBackground: true, delay: 50);
KeyBindHandler multiHandler = new KeyBindHandler(new List<Keys> {Keys.R, Keys.O, Keys.P, Keys.E }, CheckModes.PRESSED, isBackground: true, delay: 50);

// to start the handler's thread
singleHandler.Start();
multiHandler.Start();

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

