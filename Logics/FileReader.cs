using BookRoom.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookRoom.Logics
{
    public class FileReader<T> where T:class
    {
        public List<T> ReadFromJson(string path)
        {
            if (string.IsNullOrWhiteSpace(path)) throw new ArgumentNullException("Path is invalid.");
            if (!File.Exists(path)) throw new FileNotFoundException();


            return null;
        }
    }
}
