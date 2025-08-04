Name Sorter 
===========

A Project by Jonathan Piltz  <br /> <br />
Initial Release Date: July 30, 2025 <br />
Project Last Revised: August 4, 2025

## Description
A simple C# console application that sorts a list of names by Last Name, then First Name and finally by Middle Name(s) if they exist. <br />
The results of the sorting will be output to the Console as well as to a text file named "sorted-names-list.txt". This text file will be output to the same 
folder path as the source file if it doesn't exist already. If it does, it will be overwritten. 

## Technologies
- ASP.NET Core 8.0 with C#
- Xunit (for testing)

## Prerequisites
- [.NET 8 SDK] ( https://dotnet.microsoft.com/download )
- Optional: Visual Studio or VS Code

## Instructions
To run, open up PowerShell, navigate to where the executable is located. Afterwards, type in ".\name-sorter" followed by the path to the source file. 
The whole line should look like: <br />
.\name-sorter "C:\Text_Files\unsorted-names-list.txt"
