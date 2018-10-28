﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestNinja.Mocking
{
    public interface IFileReader
    {
        string read(string path);
    }

    public class FileReader : IFileReader
    {
        public string read(string path)
        {
            return File.ReadAllText(path);
        }
    }
}
