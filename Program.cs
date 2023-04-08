using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Configuration;

namespace Cats_5
{
    class Program
    {
        static void Main()
        {
            string line;
            int words = 1;
            using (FileStream file = File.OpenRead("d.in.txt"))
            {
                byte[] array = new byte[200];
                file.Read(array, 0, 200);
                line = Encoding.Default.GetString(array);
            }

            for (int i = 0; i < line.Length; i++)
            {
                if (line[0] == '\n')
                {
                    words = 0;
                    break;
                }

                if ((i > 0) && 
                    line[i - 1] != ',' && 
                    line[i - 1] != '.' && 
                    line[i - 1] != '!' && 
                    line[i - 1] != '?' &&
                    line[i - 1] != '-' &&
                    line[i] == ' ' && 
                    line[i + 1] != ' ' && 
                    line[i + 1] != '-' && 
                    line[i + 1] != '.' && 
                    line[i + 1] != ',' && 
                    line[i + 1] != '!' && 
                    line[i + 1] != '?' && 
                    line[i + 1] != '\n')
                    words ++;

                if (line[i] == '.' && 
                    line[i + 1] != '.' && 
                    line[i + 1] != ',' && 
                    line[i + 1] != '!' && 
                    line[i + 1] != '?' && 
                    line[i + 1] != '\n' && 
                    line[i - 1] != ' ')
                    words ++;

                if (line[i] == ',' && 
                    line[i + 1] != '.' && 
                    line[i + 1] != ',' && 
                    line[i + 1] != '!' && 
                    line[i + 1] != '?' && 
                    line[i + 1] != '\n')
                    words++;

                if (line[i] == '!' && 
                    line[i + 1] != '.' && 
                    line[i + 1] != ',' && 
                    line[i + 1] != '!' && 
                    line[i + 1] != '?' && 
                    line[i + 1] != '\n' && 
                    line[i - 1] != ' ')
                    words++;

                if (line[i] == '?' && 
                    line[i + 1] != '.' && 
                    line[i + 1] != ',' && 
                    line[i + 1] != '!' && 
                    line[i + 1] != '?' && 
                    line[i + 1] != '\n' && 
                    line[i - 1] != ' ')
                    words++;

                if (line[i] == '-' && 
                    line[i + 1] != '.' && 
                    line[i + 1] != ',' && 
                    line[i + 1] != '!' && 
                    line[i + 1] != '?' && 
                    line[i + 1] != '\n' && 
                    line[i + 1] == ' ' && 
                    line[i - 1] == ' ')
                    words++;
            }

            using (FileStream file = new FileStream("d.out", FileMode.OpenOrCreate))
            {
                byte[] array = Encoding.Default.GetBytes(Convert.ToString(words));

                file.Write (array, 0, array.Length);    
            }
        }
    }
}
