using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment.Repository
{
    public abstract class FileManager
    {
        private readonly object _lockTransaction = new object();
        public void WriteToFile(string text, string path)
        {
            lock (_lockTransaction)
            {


                File.WriteAllTextAsync(path, text);
            }
        }

        public async Task<string> ReadAllText(string path)
        {
            if (!File.Exists(path))
            {
                return null;
            }
            return await File.ReadAllTextAsync(path);
        }
    }
}
