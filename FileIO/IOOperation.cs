using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace FileIO
{
    public class IOOperation
    {
        public List<string> GetFile(string file)
        {
            List<string> log = new List<string>();
            try
            {

                using (FileStream stream = System.IO.File.Open(file, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                {
                    using (TextReader reader = new StreamReader(stream))
                    {
                        string line;
                        while ((line = reader.ReadLine()) != null)
                        {
                            log.Add(line);
                        }
                    }
                }
            }
            catch (Exception ex) { throw ex; }
            return log;
        }

        public List<string> GetFile(string file, int lines)
        {
            List<string> log = new List<string>();
            try
            {

                using (FileStream stream = System.IO.File.Open(file, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                {
                    using (TextReader reader = new StreamReader(stream))
                    {
                        string line;
                        while ((line = reader.ReadLine()) != null)
                        {
                            log.Add(line);
                        }
                    }
                }
            }
            catch (Exception ex) { throw ex; }
            return log.Reverse<string>().Take(lines).ToList();
        }
    }
}
