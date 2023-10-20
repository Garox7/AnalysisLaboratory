using System;
using LaboratoryLibrary.Classes;

class Program
{
    static void Main()
    {
        JsonFileManager jsonFile = new();

        jsonFile.ReadJsonFile();
    }
}