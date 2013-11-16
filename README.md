S-Cubed--VideoStore--CSharp
===========================

Create a virtual 'Blockbuster', with a membership list and video inventory. This code uses C#, instead of the original Java.

Inluded in this repository are the C# files necessary to compile and run the application. I used Visual Studio Express to create this program. Also included are two CSV files, one for video store members and the other for video inventory, that can be used as arguments. These text files can be edited as you see fit, or you may use your own. They will be included in the root of this repository.

If you are to edit or use your own file, there must not be any space between each segment of the line. For example, if I want to add another person to the file I must write it as "X,Y,123456" (without quotation marks). The format for a new customer is first name, last name, and a 10-digit numerical code. There are two formats that are acceptable in the film text file: (1) film name, year, 6-digit numerical code, or (2) film name, year, 6-digit numerical code, number of tapes.

The first argument must be the file for video store members, and the second must be for the video inventory. The Program.cs file is where the main function can be found. Program.exe in the VideStore folder will run the program in a command prompt, but it will still require the use of the two arguments.

If compiling in a command prompt, all four cs files are necessary for a sucessful compile operation.