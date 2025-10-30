using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookRoom.Logics
{
    public interface IFileReader
    {
        string ReadFile(string path);
        bool FileExists(string path);
    }
}
