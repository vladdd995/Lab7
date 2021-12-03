using System;
using System.IO;

namespace Lab7
{
    class GISTO
    {
        public static string entropy(string path)
        {
            try
            {
                return GISTO.start(File.ReadAllBytes(path)).ToString();
            }
            catch
            {
                return "Ентропія:  ???";
            }
        }

        private static double start(byte[] MyArr1)
        {
            int[] MyArr2 = new int[256];
            Buffer.BlockCopy((Array)GISTO.GISTO_e(MyArr1), 0, (Array)MyArr2, 0, 1024);
            int length = MyArr1.Length;
            return GISTO.GISTO_entropy(MyArr2, length);
        }

        private static int[] GISTO_e(byte[] MyArr1)
        {
            int[] numArray = new int[256];
            foreach (byte num1 in MyArr1)
            {
                int num2 = numArray[(int)num1] + 1;
                numArray[(int)num1] = num2;
            }
            return numArray;
        }

        private static double GISTO_entropy(int[] MyArr2, int N)
        {
            double num1 = 0.0;
            foreach (double num2 in MyArr2)
            {
                double a = num2 / (double)N;
                if (a != 0.0)
                {
                    double num3 = a * -Math.Log(a, 2.0);
                    num1 += num3;
                }
            }
            return num1;
        }
    }
}

