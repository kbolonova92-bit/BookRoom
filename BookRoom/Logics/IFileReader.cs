namespace BookRoom.Logics;

public interface IFileReader
{
    string ReadFile(string path);
    bool FileExists(string path);
}
