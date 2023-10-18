using Newtonsoft.Json;
namespace LaboratoryLibrary.Classes;
// dotnet add PROGETTO DOVE VA USATO reference PROGETTO DA USARE

// definiamo un delegate per la lettura di un file JSON
public delegate T JsonReader<T>(string filePath);

// definiamo un delegate per la scrittuta di un file JSON
public delegate string JsonWriter<T>(T data, Formatting indent);

// Metodo per generivo per leggere un file JSON
public class JsonFileManager
{
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
       string jsonData = jsonWriter(data, Formatting.Indented);
       File.WriteAllText(filePath, jsonData);
    }
}