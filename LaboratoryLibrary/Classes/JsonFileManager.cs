using System.Runtime.CompilerServices;
using Newtonsoft.Json;
using LaboratoryLibrary;


// dotnet add PROGETTO DOVE VA USATO reference PROGETTO DA USARE

namespace LaboratoryLibrary.Classes;

public class JsonFileManager
{
    // definiamo un delegate per la lettura di un file JSON
    public delegate T JsonReader <T>(string filePath);

    // definiamo un delegate per la scrittuta di un file JSON
    public delegate string JsonWriter<T>(T data);
    // Metodo per generivo per leggere un file JSON

    public T ReadJsonFile<T>(string filePath, JsonReader<T> jsonReader)
    {
        if(File.Exists(filePath))
        {
            string jsonData = File.ReadAllText(filePath);
            return jsonReader(jsonData);
        }
        else
        {
            throw new FileNotFoundException($"File not foud: {filePath}");
        }
    }
    //Metodo per scrivere un file JSON
    public void WriteJsonFile<T>(string filePath, T data, JsonWriter<T> jsonWriter)
    {
       string jsonData = jsonWriter(data);
       File.WriteAllText(filePath, jsonData);

    }
}

//controllare se funzionadotenet 