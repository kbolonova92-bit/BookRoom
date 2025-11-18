namespace BookRoom.Logics;

public class FileReader: IFileReader
{
    public string ReadFile(string path) => File.ReadAllText(path);

    public bool FileExists(string path) => File.Exists(path);
}
