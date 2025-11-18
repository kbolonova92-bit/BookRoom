using System.Text.Json;

namespace BookRoom.Logics;

public class FileParser
{
    public IFileReader _reader;
    public FileParser(IFileReader reader) 
    {
        _reader = reader;
    }

    public List<T> ReadFromJson<T>(string path) where T : class
    {
        if (string.IsNullOrWhiteSpace(path)) throw new ArgumentNullException("Path is invalid.");

        if (!_reader.FileExists(path)) throw new FileNotFoundException();

        string fileBody = _reader.ReadFile(path);

        return JsonSerializer.Deserialize<List<T>>(fileBody);
    }
}
