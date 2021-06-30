using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HeapSortVisual
{

    public class HeapSort
    {
        int[] array;
        Form1 frm;
        int max=0 , left=0 , right=0,index=0;
        public List<SwapValue> swapValues = new List<SwapValue>();
        public  HeapSort(Form1 form,int[] arr)
        {
            frm = form;
            array = arr;
            int size = array.Length;
            BuildHeap();
            for (int i = size - 1; i >= 0; i--)
            {
                swap(0,i);
                heapify(i, 0);
            }
        }
        public void BuildHeap()
        {
            int size = array.Length;

            for (int i = size / 2 - 1; i >= 0; i--)
                heapify( size, i);
        }
        public void heapify( int n, int t)
        {
             max = t;
             index = t;
             left = 2 * t + 1;
             right = 2 * t + 2;

            if (left < n && array[left] > array[max])
                max = left;

            if (right < n && array[right] > array[max])
                max = right;

            if (max != t)
            {
                swap(t,max);
                heapify( n, max);
            }

        }
        public void swap(int i, int j)
        {
            // Records each step in type of SWAPVALUE
            if (index < array.Length && max < array.Length && left < array.Length && right < array.Length)
            {
                SwapValue swapValue = new SwapValue(array,max,left,right,index,i,j);
                swapValues.Add(swapValue);
            }
            int temp = array[i];
            array[i] = array[j];
            array[j] = temp;
        }
    }
}
