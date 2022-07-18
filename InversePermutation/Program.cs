using System;

namespace InversePermutation
{
    internal class Program
    {
        static void Main(string[] args)
        {

            int N = 5;
            int[] Arr = { 2, 3, 4, 5, 1 };
            var Arrayreponse = InversePermutation(Arr, N);

            foreach(int ar in Arrayreponse)
                Console.Write(ar + " ");
        }


        static int[] InversePermutation(int[] Arr, int N)
        {

           int[] StoringArr = new int[N];
           
            for (int i = 0; i < N; i++)
                StoringArr[Arr[i] - 1] = i + 1;

            return StoringArr;
        }

    }
}
