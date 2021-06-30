using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LZW
{
    class Program
    {
        static void Main(string[] args)
        {
            // you can use this sentence: wabba/wabba/wabba/woo/woo/woo/wabba//wabba/woo
            String sentence;
            Console.WriteLine("Please,Enter a sentence ");
            sentence = Console.ReadLine();
            LZW lzw = new LZW(sentence);
            Console.WriteLine("Result:");
            lzw.printCode();
            lzw.printDictionary();
            Console.Read();
        }
    }
}
