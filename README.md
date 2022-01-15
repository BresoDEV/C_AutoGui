
<h1>C# PyAutoGUI</h1><br >
<p>Based on the famous tool in Python, PYAUTOGUI
I present to you, a class in C# with similar functionality
With this tool, you can control your mouse and keyboard 
automatically, so you can easily create task automation
for inumerous things</p>

<hr />
<h1>Documentation</h1><br >

<p><a href=https://github.com/BresoDEV/C_AutoGui/blob/main/README.md#how-to-use> How to use/install </a></p>
<p><a href=https://github.com/BresoDEV/C_AutoGui/blob/main/README.md#mouse-functions> Mouse Events </a></p>
<p><a href=https://github.com/BresoDEV/C_AutoGui/blob/main/README.md#keyboard-events> Keyboard Events </a></p>
<p><a href=https://github.com/BresoDEV/C_AutoGui/blob/main/README.md#other-events> Other Events </a></p>
<p><a href=https://github.com/BresoDEV/C_AutoGui/blob/main/README.md#convertto-events> ConvertTo Events </a></p>


<hr />

<h1>How to Use:</h1><br >
<p>DLL:
</p>



```
Create your project
Click on Add Reference
Browse and select Cyautogui.dll
Click OK
Done

```





<p>Class</p>



```
Create your project
Click on Add New Item
Select Class
Put any name you want
Copy and paste all code to your new class file 
Done

```

<hr />



<p>Mouse Options::
</p>



```bash
Do a mouse right clik on current mouse position
Move cursor to XY pos and do right click
Move cursor relative to current position and do right click
Do a mouse clik on current mouse position
Move cursor to XY pos and do click
Move cursor relative to current position and do click
Do double click on current position
Move cursor to XY position and do double click
Move cursor to XY current relative position and do double click
Move the mouse to XY coordinates
Move mouse relative to its current position
Get the Y position of the mouse
Get the X position of the mouse
Get the Y position of the mouse on STRING format
Get the X position of the mouse on STRING format
```




<hr />
<p>Keyboard Options::
</p>



```bash
Shift Hotkey Function
Alt Hotkey Function
Ctrl Hotkey Function
TAB key
Write string, simulates keyboard
Write Loop, Used to press same key, what times you want
Simulate keyboard press
```




<hr />
<p>Misc Options::
</p>



```bash
Change Global Time Pointer (functions delay)
Start another process by name
Open folders or files on your PC
Get the size X of the primary monitor on string format
Get the size Y of the primary monitor on string format
Get the size X of the primary monitor
Get the size Y of the primary monitor
Displays some text with an OK button.
Pause code option
Join several string and make onlt one
```




<hr />
<p>Convert Options::
</p>



```bash
Convert INT value to DOUBLE
Convert STRING value to DOUBLE
Convert STRING to INT32
Convert FLOAT to INT32
Convert INT value to STRING
Convert FLOAT value to STRING
Convert DOUBLE value to STRING
```




<hr />


<h1>Mouse Functions:</h1><br >
<p>Do a mouse right clik on current mouse position</p>



```bash
cyautogui.Mouse.DoMouseRightClick()
```





<br >

<p>Move cursor to XY pos and do right click</p>



```CSharp
cyautogui.Mouse.MoveAndRightClick(posX, posY)
```





<br >

<p>Move cursor relative to current position and do right click</p>



```CSharp
cyautogui.Mouse.MoveCursorRelAndRightClick(posX, posY)
```





<br >

<p>Do a mouse clik on current mouse position</p>



```CSharp
cyautogui.Mouse.DoMouseClick();
```





<br >


<p>Move cursor to XY pos and do click</p>



```CSharp
cyautogui.Mouse.MoveAndClick(posX, posY);
```





<br >

<p>Move cursor relative to current position and do click</p>



```CSharp
cyautogui.Mouse.MoveCursorRelAndClick(posX, posY);
```





<br >

<p>Do double click on current position</p>



```CSharp
cyautogui.Mouse.DoMouseDoubleClick();
```





<br >

<p>Move cursor to XY position and do double click</p>



```CSharp
cyautogui.Mouse.MoveAndDoubleClick(posx, posy);
```





<br >



<p>Move cursor to XY current relative position and do double click</p>

```CSharp
cyautogui.Mouse.MoveCursorRelAndDoubleClick(int x, int y) 
 ```

<br >
<p>Move the mouse to XY coordinates</p>

```CSharp
cyautogui.Mouse.MoveCursorTo(int x, int y)  
 ```

<br >
<p>Move mouse relative to its current position</p>
 
```CSharp
cyautogui.Mouse.MoveCursorRel(int x, int y) 
 ``` 

<br >
<p>Get the Y position of the mouse</p>

```CSharp
cyautogui.Mouse.getMouseY() 
 ```
 
<br >
<p>Get the X position of the mouse</p>


```CSharp
cyautogui.Mouse.getMouseX()  
 ```

<br >
<p>Get the Y position of the mouse on STRING format</p>


```CSharp
cyautogui.Mouse.StringgetMouseY()  
 ```

<br >
<p>Get the X position of the mouse on STRING format</p>


```CSharp
cyautogui.Mouse.StringgetMouseX() 
 ```
 
 <br >
 
 <hr />
<h1>Keyboard Events:</h1><br >

 
<p>Shift hotkeys</p>

```CSharp
cyautogui.Keyboard.ShiftHotkey(string key) 
```   
 
 <br >
<p>Alt hotkeys</p>
 
```CSharp
cyautogui.Keyboard.AltHotkey(string key) 
```   
 
 <br >
<p>TAB</p>

```CSharp
cyautogui.Keyboard.TAB(int times) 
```   
 
 <br >
<p>CTRL hotkeys</p>

```CSharp
cyautogui.Keyboard.CTRLHotkey(string key) 
```   
 
 <br >
<p>Write strings</p>

```CSharp
cyautogui.Keyboard.Write(string key) 
```   
 
 <br >
<p>Used to press same key, what times you want </p>

```CSharp
cyautogui.Keyboard.WriteMoreThan1time(string key, int times) 
```   
 
 <br >
<p>Simulate keyboard press</p>

```CSharp
cyautogui.Keyboard.KeyPress(string key) 
```   
	 
 <br >
<hr />
<h1>Other Events:</h1><br >
<br >

 
<p>Define your new Global Wait Timer, default is 500</p>


```CSharp
cyautogui.Other.ChangeGlobalTimePointer(int time)
 ```

<br >

<p>Start another process by name</p>


```CSharp
cyautogui.Other.StartProcess(string proc)
 ```

<br >

<p>Used to open folders or files on your PC</p>


```CSharp
cyautogui.Other.OpenFolder(string path)
 ```

<br >

<p>Get the size X of the primary monitor on string format</p>
 
```CSharp
cyautogui.Other.StringsizeScreenX()
 ```

<br >

<p>Get the size Y of the primary monitor on string format</p>

```CSharp
cyautogui.Other.StringsizeScreenY()
 ```

<br >

<p>Get the size X of the primary monitor</p>

```CSharp
cyautogui.Other.sizeScreenX()
 ```

<br >

<p>Get the size Y of the primary monitor</p>

```CSharp
cyautogui.Other.sizeScreenY()
 ```

<br >

<p>This displays some text with an OK button.</p>

```CSharp
cyautogui.Other.alert(string msg)
 ```

<br >

<p>Do some pause on code.</p>

```CSharp
cyautogui.Other.Wait(int timeMiliseconds)
 ```

<br >


<p>Join several string and make onlt one</p>

```CSharp
cyautogui.Other.AddString(.....);
```

<br >



<h1>ConvertTo Events:</h1><br >

  
<p>Convert INT value to DOUBLE</p>
 
```CSharp
cyautogui.ConvertTo.toDouble(int value);
```

<br >

<p>Convert STRING value to DOUBLE</p>

```CSharp
cyautogui.ConvertTo.toDouble(string value);
```

<br >

<p>Convert STRING to INT32</p>

```CSharp
cyautogui.ConvertTo.toInt(string value);
```

<br >

<p>Convert FLOAT to INT32</p>
 
```CSharp
cyautogui.ConvertTo.toInt(float value);
```

<br >

<p>Convert INT value to STRING</p>
 
```CSharp
cyautogui.ConvertTo.toString(int key);
```

<br >

<p>Convert FLOAT value to STRING</p>
 
```CSharp
cyautogui.ConvertTo.toString(float key);
```

<br >
<p>Convert DOUBLE value to STRING</p>

```CSharp
cyautogui.ConvertTo.toString(double key);
```

<br >
