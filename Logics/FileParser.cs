using BookRoom.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookRoom.Logics
{
    public class FileParser<T> where T:class
    {
        public IFileReader _reader;
        public FileParser(IFileReader reader) 
        {
            _reader = reader;
        }

        public List<T> ReadFromJson(string path)
        {
            if (string.IsNullOrWhiteSpace(path)) throw new ArgumentNullException("Path is invalid.");
            if (!_reader.FileExists(path)) throw new FileNotFoundException();

            string fileBody = _reader.ReadFile(path);

            return null;
        }
    }
}
