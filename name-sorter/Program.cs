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

        TextFileReader reader = new TextFileReader();
        TextFileWriter writer = new TextFileWriter();
        NameParser parser = new NameParser();
        NameSorter sorter = new NameSorter(parser);
        NameDisplayer displayer = new NameDisplayer();
        FolderFinder folderFinder = new FolderFinder();

        NameService service = new NameService(reader, writer, sorter, displayer, folderFinder);
         service.runService(fileName);

    } 



   

    

}