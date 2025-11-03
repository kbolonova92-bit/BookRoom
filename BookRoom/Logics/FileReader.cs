using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookRoom.Logics
{
    public class FileReader: IFileReader
    {
        public string ReadFile(string path) => File.ReadAllText(path);

        public bool FileExists(string path) => File.Exists(path);
    }
}
