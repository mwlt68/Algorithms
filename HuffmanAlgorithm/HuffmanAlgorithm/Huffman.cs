using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HuffmanAlgorithm
{
    public class Huffman
    {
        public static int countN=0;
        public string sentence;
        public char specialChar = '*';

        List<Branch> branchs = new List<Branch>();
        List<Branch> branchsRoot = new List<Branch>();

        public Huffman(string sent)
        {
            this.sentence = sent;
        }

        public void createBranchList()
        {
            foreach (char c in sentence)
            {
                if (!ısCharInBranchList(branchs, c))
                {
                    branchs.Add(new Branch(c, 1));
                }
                else
                {
                    foreach (Branch branch in branchs)
                    {
                        if (c == branch.character)
                        {
                            branch.frequency++;
                        }
                    }
                }
            }
            branchsRoot = branchs;
        }

        public bool ısCharInBranchList(List<Branch> branchs, Char c)
        {
            foreach (Branch branch in branchs)
            {
                if (c == branch.character)
                {
                    return true;
                }
            }
            return false;
        }

        public void Sort()
        {
            branchs.Sort();
        }

        public Branch createAllBranch()
        {
            while (!allVisitedControl(branchs))
            {
                foreach (var branch in branchs.ToArray())
                {
                    if (branch.visited==false)
                    {
                        int index = branchs.IndexOf(branch);
                        Branch nextBranch = branchs.ElementAt(index + 1);
                        Branch branchClon = new Branch(specialChar, branch.frequency + nextBranch.frequency);
                        branchClon.leftBranch = branch;
                        branch.parent = branchClon;
                        nextBranch.parent = branchClon;
                        branchClon.rightBranch = nextBranch;
                        branchs.Add(branchClon);
                        branch.visited = true;
                        nextBranch.visited = true;
                        branchs.Sort();
                        break;
                    }
                }
            }
            return branchs.Last<Branch>();
        }

        public bool allVisitedControl(List<Branch> branches)
        {
            foreach (var branch in branches)
            {
                if (branch != branches.Last<Branch>() && branch.visited == false)
                    return false;
            }
            return true;
        }
        public string comressedCode()
        {
            string code = "";
            findAllBranchComressedCode();

            foreach (var c in sentence)
            {
                foreach (var branch in branchs)
                {
                    if (c==branch.character)
                    {
                        code += branch.code + "-";
                    }
                }
            }
            return code;
        }
        public void findAllBranchComressedCode()
        {
            foreach (var item in branchs)
            {
                if (item.character == specialChar)
                    continue;
                else
                    item.code = findCodeInTree(item);
            }
        }
        public string findCodeInTree(Branch branch)
        {
            String reverseCode = "";

            while(branch.parent != null)
            {
                if (branch.parent.leftBranch == branch)
                {
                    reverseCode += "0";
                }
                else
                    reverseCode += "1";

                branch = branch.parent;
            }
            
            return reverseString(reverseCode);
        }
        public string reverseString(String str)
        {
            string result="";
            for (int i = str.Length-1; i >= 0; i--)
            {
                result += str[i];
            }
            return result;
        }
        public void printTree()
        {
            Console.WriteLine("Count    Char    Freq    Code");
            int counter = 1;
            foreach (var item in branchs)
            {
                if (item.character == specialChar)
                    continue;
                else
                {
                    Console.WriteLine(counter++ + "\t" + item.character + "\t" + item.frequency + "\t" + item.code);
                }
            }
        }
    }

    public class Branch : IComparable<Branch>
    {
        public char character;
        public int frequency;
        public Branch parent;
        public Branch leftBranch;
        public Branch rightBranch;
        public bool visited=false;
        public string code; // Comressed Binary Code
        public Branch(Char ch, int freq)
        {
            this.character = ch;
            this.frequency = freq;
            leftBranch = null;
            rightBranch = null;
        }
        public int CompareTo(Branch other)
        {
            return frequency - other.frequency;
        }
    }
}
