# tymaker GUI testing
Generates Thank-You notes from information. This version of tymaker uses a wrapper for [Zenity](https://gitlab.gnome.org/GNOME/zenity), so that may be needed for this program to work. Windows, without proper support for Zenity, has not been tested, and you can make a pull request if you figured out how to get this to run on Windows. This GUI design is not final and will change when I learn to use Xamarin.Forms.
# Building Instructions
## Github Actions
The easiest way to use the program is to download the latest build from [![Tymaker Builds](https://github.com/Anti-Apple4life/tymaker-group/actions/workflows/tymaker.yml/badge.svg)](https://github.com/Anti-Apple4life/tymaker-group/actions/workflows/tymaker.yml).
## Using `dotnet` (Requires [Dotnet SDK](https://dotnet.microsoft.com/en-us/download/dotnet/6.0))
You can build to your own liking using the `dotnet` command. This offers more control than using the Makefile and downloading a build. It is not reccomended for beginners, however.
## Using `make` (Requires [Dotnet SDK](https://dotnet.microsoft.com/en-us/download/dotnet/6.0))
The easiest way to build tymaker yourself is to use the Makefile included. Simply clone this repository, enter the repository folder, and type in `make`. A folder called `publish` will be created, and the build will be there.
## Installing
After running `make`, you can run `sudo make install` to install the build in the `publish` folder to your `/usr/bin` directory.
# Disclaimer
All new features are tested on Arch Linux, so no guarantees it will work anywhere else. I also cannot guarantee that it will work at all and that your PC will not explode (Thanks MIT license)
