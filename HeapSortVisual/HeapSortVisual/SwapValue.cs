using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeapSortVisual
{
    public class SwapValue
    {
        public int[] array;
        public int max = 0, left = 0, right = 0, index = 0,swapI=0,swapJ=0;
        public SwapValue(int[] arr, int m, int l, int r, int i, int swapI, int swapJ)
        {

            max = arr[m];
            left = arr[l];
            right = arr[r];
            index = arr[i];
            this.swapI = swapI;
            this.swapJ = swapJ;
            this.array = (int[]) arr.Clone();
        }
    }
}
