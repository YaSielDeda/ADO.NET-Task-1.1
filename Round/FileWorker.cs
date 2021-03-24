using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Round
{
    public class FileWorker
    {
        static string path = @"input.txt";
        public string Load()
        {
            string str = null;

            #region file loading
            try
            {
                FileStream stream = new FileStream(path, FileMode.Open);
                StreamReader reader = new StreamReader(stream);
                str = reader.ReadToEnd();
                stream.Close();
            }
            catch
            {
                throw new Exception("The file is corrupted or missing");
            }
            return str;
            #endregion
        }
        public void PrintFile(Round r)
        {
            using (StreamWriter sw = new StreamWriter("output.txt", false, System.Text.Encoding.Default))
            {
                StringBuilder str = new StringBuilder("x=" + r.Center.X + "\\y=" + r.Center.Y + "\\r=" + r.Radius + "\\");
                sw.Write(str);
            }
        }
    }
}
