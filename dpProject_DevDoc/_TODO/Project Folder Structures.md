
17 Nov 14.30
UI Reference: https://www.figma.com/make/IvfzXenXWcQF5l81HEPeD0/Project-Management-Desktop-UI?t=QDuVxj3PyGuCrlBH-1 
In the project, there is a folder with these structures. Use these as your reference

```
<dpProject>
	 ├── asset/                             <-- Master directory for asset
	 ├────── ico/                           <-- Use all icons from here in all ui
	 ├───────── download.svg/
	 ├────── media/                         <-- asset like animation or gif
	 ├────── app_20x20.icns/                <-- Master App Icons
	 ├────── app_20x20.ico/
     ├── bin/                      
     ├── int/            
     ├────── element/ 
     ├───────── logical/                    <-- The c# code for xaml ui only
     ├──────────── method/                  <-- All function/method goes here
     ├─────────────── math_data_avg.cs/     <-- For example: calculation logic
     ├──────────── card.cs                  <-- Only for xaml ui c# code behind
     ├───────── rules/                      <-- Folder for UI Style rules
     ├──────────── color.xaml
     ├───────── card.axaml                  <-- The xaml ui design code
     ├────── win/                           <-- will used for window, structure same as element
     ├── obj/           
     ├── App.axaml
     ├── App.axaml.cs
     ├── app.manifrest
     ├── dpProject.csproj
     ├── init.axaml                         <--Mastermind of the UI
     ├── init.cs                            <--Code Behind Mastermind UI
     └── Program.cs                         <--Launcher
```

TASK: Refractor the code, especially the init.xaml ui based on these rules

* Project Structuring Rules
	* Every csharp code contains code behind of the xaml ui MUST be inside a "logical" folder (create it if unavailable).
	* Every csharp code contents logical method like math calculations, api configuration, etc inside a "method" folder inside a "logical" subfolder per class
	* Example: The class "dpProjectMan.Client" to handle user as a studio client able to create and manipulate project inside studio. Inside the folder, there's a "/logical/method" folder, and inside the root class folder ("dpProjectMan.Client"), there's a folder called "element" contains the code of the ui element. Try to llink the UserControl axaml from "./element" to their code behind inside "./logical" and link the logical code to the code behind inside "./logical/method" if there's any logical function codes.
* Make Lots of Changes in the UI
	* Build the UserControl UI For "Recent Projects", "Work Statistics", "Youtube Studio", "Notifications", "Settings", and "UserProfile", and link it to the "radiobutton" tab in the Side Panel with a slide left / right animation.
		* Use Native Web Browser for Youtube Studio. (Just for Testing), and don't forget to make sure when user open the YT Studio Tab, make the web browser fits to the current windows size
	* Remove all the Addressbar in the UI (the MayaTrack > ...) we do not need mayatrack text because it just a demo ui prototype test
	* Modify the content inside home with the multi viewtype support between list and cards when the toggle is pressed (Make sure the UI is flexible with any window size)
* Refractor the main ui (init.axaml and cs) to the int folder.
	* Put the tabs UI such as Side Panel, "Home", "Recent Projects", "Work Statistics", "Youtube Studio", "Notifications", "Settings", and "UserProfile" UserControl axaml code inside "./int/element", code behind inside "./int/element/logical" and method or any logical class inside "./int/element/logical/method".
	* After that, link all the created tabs and side panels into the MasterMind of the UI, which is init.axaml and init.axaml.cs.
	* Make sure the dark and light theme follows the system settings even when user or system changes the system theme while app is running.

Make sure when you refractor the code, follow these code creation rules and folder structures and don't miss it.