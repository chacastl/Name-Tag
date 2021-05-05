This was a attempt to make a setup file for the Name Tag program.

Issues I ran into:

FIXED
------
SkiaSharp.dll is having problems when turning into a setup file.
Other DYMO .dll's are having problems when turning into a setup file.

may be because of older drivers or no support for setups with DYMO librarys.

The Errors I was hitting was because it was not importing the XML files during the Setup Process as well, adding those into the setup process got it working.
