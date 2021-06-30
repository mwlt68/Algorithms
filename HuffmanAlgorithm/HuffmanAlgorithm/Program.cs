using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HuffmanAlgorithm
{
    class Program
    {
        static void Main(string[] args)
        {
            String sentence = "";
            String compressedCode;
            Branch root = null;
            Console.WriteLine("Please , Enter a sentence (you dont use * char because * is special char)");
            sentence=Console.ReadLine();
            Huffman huffman = new Huffman(sentence);
            huffman.createBranchList();
            huffman.Sort();
            root=huffman.createAllBranch();
            compressedCode=huffman.comressedCode();
            Console.WriteLine("Your compressed code:");
            Console.WriteLine(compressedCode);
            huffman.printTree();
            Console.Read();
        }
    }
}
