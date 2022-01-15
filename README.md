
<h1>C# PyAutoGUI</h1><br >
<p>Based on the famous tool in Python, PYAUTOGUI
I present to you, a class in C# with similar functionality
With this tool, you can control your mouse and keyboard 
automatically, so you can easily create task automation
for inumerous things</p>

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
