using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LZW
{
    public class LZW
    {
        String sentence;
        public List<String> dictionary = new List<string>();
        public List<Int32> zipCode = new List<Int32>();
        public LZW(String str)
        {
            sentence = str;
            createLZW();
        }
        public void  createLZW()
        {
            createDictRoot();
            string tempStr = "";
            int counter = 0;
            foreach (var chr in sentence)
            {
                int control = isThisInDict(tempStr + chr);
                if (control != -1)                               // dictionary include (tempstr+chr) 
                {
                    
                    tempStr += chr;
                    if (counter == sentence.Length - 1)
                    {
                        zipCode.Add(control);
                    }
                }
                else
                {
                    control = dictionary.Count;
                    zipCode.Add(control);
                    dictionary.Add(tempStr + chr);
                    tempStr = "";
                }
                counter++;
            }

        }
        public void createDictRoot()
        {
            foreach (var chr in sentence)
            {
                if (isThisInDict(chr.ToString())==-1)
                {
                    dictionary.Add(chr.ToString());
                }
            }
        }
        public int  isThisInDict(string findWord)
        {
            int counter = 0;
            foreach (var word in dictionary)
            {
                if (word==findWord)
                {
                    return counter;                       // if you dont want use counter you can use " return dictionary.IndexOf(word); "
                }
                counter++;
            }
            return -1;
        }
        public void printCode()
        {
            foreach (int code in zipCode)
            {
                Console.Write(code +"--");
            }
            Console.Write("\n");
        }
        public void printDictionary()
        {
            Console.WriteLine("Index    Word");
            int counter = 0;
            foreach (var word in dictionary)
            {
                Console.WriteLine(counter++ +"\t"+word);
            }
        }
    }
}
