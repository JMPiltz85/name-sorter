Name Sorter 
===========

A Project by Jonathan Piltz 
Release Date: July 30, 2025

## Description
A simple C# console application that sorts a list of names by Last Name, then First Name and finally by Middle Name(s) if they exist. The results of the sorting will be output to the Console as well as to a text file named "sorted-names-list.txt", which would be output to the same folder path as the source file.

## Technologies
ASP.NET Core 8.0 with C#
Xunit (for testing)

## Prerequisites
- [.NET 8 SDK] ( https://dotnet.microsoft.com/download )
- Optional: Visual Studio or VS Code

## Instructions
To run, open up PowerShell, navigate to where the executable is and type in ".\name-sorter" followed by the path to the source file. Should look like:
.\name-sorter "C:\Text_Files\unsorted-names-list.txt"