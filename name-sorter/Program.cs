using name_sorter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;

class Program
{
    static void Main(string[] args)
    {
        //string fileName = "D:\\Users\\Jonathan\\Documents\\Interview projects\\Dye & Durham\\unsorted-names-list.txt";
        string fileName = "";

        if (args.Length > 0)
            fileName = args[0];

        TextFileReader reader = new TextFileReader(new ConsoleLogger());
        TextFileWriter writer = new TextFileWriter(new ConsoleLogger());
        NameParser parser = new NameParser( new ConsoleLogger());
        NameSorter sorter = new NameSorter(parser, new ConsoleLogger());
        NameDisplayer displayer = new NameDisplayer(new ConsoleLogger());
        FolderFinder folderFinder = new FolderFinder(new ConsoleLogger());

        NameService service = new NameService(reader, writer, sorter, displayer, folderFinder);
         service.runService(fileName);

    } 



   

    

}