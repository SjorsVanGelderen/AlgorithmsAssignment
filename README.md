# Algorithms assignment port for GNU+Linux / MacOS
For sake of convenience the port focuses on MonoDevelop / Xamarin.  
So far, I've only been able to test this on Ubuntu 16.10.  
I will be able to test it on MacOS later when my new system arrives :').  

I've also been informed that a student made a MacOS port that might work for you.  
The repository for that can be found [here](https://github.com/remcovisser/Dev020201).

# Note
The projects inside the solution have been renamed as follows:  
* Main       -> Backend
* EntryPoint -> Frontend

# Instructions Ubuntu
To use this, please do the following:
```
sudo apt install monodevelop fsharpc ttf-mscorefonts-installer gtk-sharp3 libopenal-dev
```
Agree to install the packages when apt asks you to confirm.

Then download MonoGame for Linux from [here](http://www.monogame.net/2016/03/17/monogame-3-5/).  
Open a terminal in the folder where the file is located and use the following commands:
```
sudo chmod +x monogame-sdk.run
./monogame-sdk.run
```

The first line makes the file executable(sets the correct permissions), the second executes it.  
Follow the on-screen instructions and finish installing.

Clone this repository and open the solution with MonoDevelop.  
At this point you should be able to build.  
If you cannot, you may have to add MonoGame(DesktopGL) from NuGet to both projects in the solution.  
Possibly you will also have to include FSharp through NuGet.

# MCGB.exe / nVidia error troubleshooting
Should you get an error relating to MCGB.exe, try opening the Content.mcgb file in the Content folder and rebuilding the file from within the MonoGame Pipeline Tool.

# Finally
Let me know how things go. If you have any issues, please report them on GitHub!

Cheers and good luck!
