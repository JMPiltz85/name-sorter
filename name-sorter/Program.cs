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
        ILogger logger = new ConsoleLogger();

        if (args.Length > 0)
            fileName = args[0];

        NameService service = createNAmeService(logger);


        service.runService(fileName);

    } 

    private static NameService createNAmeService(ILogger logger)
    {
        TextFileReader reader = new TextFileReader(logger);
        TextFileWriter writer = new TextFileWriter(logger);
        NameParser parser = new NameParser(logger);
        NameSorter sorter = new NameSorter(parser, logger);
        NameDisplayer displayer = new NameDisplayer(logger);
        FolderFinder folderFinder = new FolderFinder(logger);

        NameService service = new NameService(reader, writer, sorter, displayer, folderFinder, logger);

        return service;
    }

}