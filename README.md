# Ps4 Package Sender

![The Tool](https://frostyso.github.io/imgs/pkgsender.png)

This Tool Sends Pkg files to your PS4! 

It can send:
  - Games
  - Patches
  - DLC's

## Requirements
- [.Net Framework 4.6](https://www.microsoft.com/en-nz/download/details.aspx?id=48130)
- [Node.js](https://nodejs.org/)
- Node.js http-server (see below for installation)

Once Node JS is installed, open up cmd and paste this command in 

`npm install http-server` 

## How to Use
The order of which you import the pkg files does not matter. The program will automatically install in this order 

Games -> Patches -> DLC -> Themes

It will also automatically combine multi-part patches if the formatting follows the standard sony naming convention.

Using it is as easy as
```
Start the pkg installer on your ps4
Drag and drop your pkg files (or folders) to the GUI. 
Pick your server ip
Pick your PS4 IP
Wait for connection status to say connected
Process the queue!
```
**Note:** You can enable Recursive Search and drag a bunch of folders in

## Basic Features
Recursive Search:  If a folder is imported, with this option ticked, all sub-folders will be searched for pkg files.

Context Menu Options

- Requeue Item(s)
- Mark As Theme (If you are installing/uninstalling a theme use this to mark it as a theme)
- Mark For Uninstall
- Clear All


### Known problems
Installing themes is bugged for multi-part themes. This is a problem with the package installer itself, not the package sender