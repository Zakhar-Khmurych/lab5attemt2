using System;

namespace lab5try1
{
    class Program
    {
        static void Main(string[] args)
        {

            BigInteger x = new BigInteger("1234");
            BigInteger y = new BigInteger("5678");

            
            Console.WriteLine(x.Add(y));
            Console.WriteLine(x.Sub(y));
            
            Console.WriteLine(x.Karatsuba(y));
           
          // Console.WriteLine(x.Karatsuba(y));
           
           
           // Console.WriteLine(x.ToString().Substring(0, 1));
            //Console.WriteLine(x.ToString().Substring(1,1));
            
           // Console.WriteLine(x._numbersString.Substring(0, 2/2));
           // Console.WriteLine(new BigInteger(Convert.ToString(x.Karatsuba(x, y))));

            /*
            
            
            
            
            
            
            
            
            
            
            //Console.WriteLine(x);
            //Console.WriteLine(y);

            //https://www.youtube.com/watch?v=yWI2K4jOjFQ

            //Console.WriteLine(x.Add(y));
            //Console.WriteLine(x.Sub(y));

            //x*y = a*c*10^(2*(n/2))+(a*d+b*c)*10^(n/2)+bd*10^0*(n/2)
            //ac
            //bd
            //ac_plus_bd

            //Console.WriteLine(5/2);

            //int[] arr1 = { 1, 2, 3, 4, 5 };
            //int[] arr2 = { 6, 7, 8, 9, 0 };

            static string bit_depth(int[] number)
            {
                int[] length;
                length = new int[number.Length];

                string depth_res = "";

                for (int i = 0; i < length.Length; i++)
                {
                    depth_res += number[i];
                    depth_res += "*10^";
                    depth_res += length.Length - i - 1;
                    if (i < length.Length - 1)
                    {
                        depth_res += " + ";
                    }
                }

                return depth_res;
            }

            // compare; is_odd; add zero; copy 1st, copy 2nd 

            //int[] arr1 = { 1, 2, 3, 4, 5, 6, 7, 8 };
            int[] arr1 = {1, 2};
            int[] arr2 = {5, 6};

            // 2*3 + 2*1 + 3*0 + 0*1

            // Math.Pow(10, arr1.Length)
            // Console.WriteLine(((arr1[0]*arr2[0])*Math.Pow(10, arr1.Length))+((arr1[0]*arr2[1]+arr2[0]*arr1[1])*Math.Pow(10, arr1.Length-1))+arr1[1]*arr2[1]);



            static int Kar_func(int a, int b, int c, int d)
            {
                int result = 0;

                int[] arr1 = { };
                int[] arr2 = { };

                arr1 = new int[2];
                arr2 = new int[2];

                arr1[0] = a;
                arr1[1] = b;
                arr2[0] = c;
                arr2[1] = d;

                result = Convert.ToInt32(((arr1[0] * arr2[0]) * Math.Pow(10, arr1.Length) +
                                          ((arr1[0] * arr2[1] + arr2[0] * arr1[1]) * Math.Pow(10, arr1.Length - 1)) +
                                          arr1[1] * arr2[1]));

                return result;
            }

            static int Kar_func_add(int a, int b, int c, int d)
            {
                int result = 0;

                int[] arr1 = { };
                int[] arr2 = { };

                arr1 = new int[2];
                arr2 = new int[2];

                arr1[0] = a;
                arr1[1] = b;
                arr2[0] = c;
                arr2[1] = d;

                //result = Convert.ToInt32(((arr1[0]*arr2[0])*Math.Pow(10, arr1.Length)+((arr1[0]*arr2[1]+arr2[0]*arr1[1])*Math.Pow(10, arr1.Length-1))+arr1[1]*arr2[1]));
                result = Convert.ToInt32(arr1[0] * Math.Pow(10, arr1.Length * 2) +
                                         (arr1[1] + arr2[0]) * Math.Pow(10, arr1.Length) + arr2[1]);

                return result;
            }

/*
            Console.WriteLine(Kar_func(1, 2, 5, 6)); // 10^length
            Console.WriteLine(Kar_func(5, 6, 3, 4)); // sum; 10^length/2
            Console.WriteLine(Kar_func(1, 2, 7, 8));
            Console.WriteLine(Kar_func(3, 4, 7, 8)); // 10^0

            Console.WriteLine(Kar_func_add(672, 1904, 936, 2652));
*/

/*
            static string Kar_generic(int[] num1, int[] num2)
            {
                string result = "";
 
                int ac = (Kar_func(num1[0], num1[1], num2[0], num2[1])); // 10^length
                int cb = (Kar_func(num2[0], num2[1], num1[2], num1[3])); // sum; 10^length/2
                int ad = (Kar_func(num1[0], num1[1], num2[2], num2[3]));
                int bd = (Kar_func(num1[2], num1[3], num2[2], num2[3])); // 10^0

                result = Convert.ToString(Kar_func_add(ac, cb, ad, bd));

                return result;
            }

            int[] array1 = {1, 2, 3, 4};
            int[] array2 = {5, 6, 7, 8};

            string xx = Kar_generic(array1, array2);

            Console.WriteLine(xx);

               // .. int[] arrpke   1u\



        }


            // два -- карфунк
            // чотрири -- карфунк і загальний
            // вісім -- карфунк і загальний х4, потім загальний
            // шістнадцять -- карфунк і загальний х4, потім загальний х4, потім загальний
            // тридцять два -- карфунк і загальний х4, потім загальний х4, потім загальний х4, потім загальний
            
            
            
            
            // 12*56; 12*78 + 34*56; 34*78; 
            // 1*2 * 10^2
            
            

            
            
            
            //Console.WriteLine(bit_depth(arr1));
            
            static int[] Karatsuba(int[] num1, int[] num2)
            {
                int length = num1.Length;
                int[] split_a = new int[num1.Length/2];
                int[] split_b = new int[num1.Length-num1.Length/2];
                int[] split_c = new int[num2.Length/2];
                int[] split_d = new int[num2.Length-num2.Length/2];

                for (int i = 0; i < num1.Length/2; i++)
                {
                    split_a[i] = num1[i];
                    split_c[i] = num2[i];
                }
                for (int i = num1.Length/2; i < num1.Length-num1.Length/2; i++)
                {
                    split_b[i] = num1[i];
                    split_d[i] = num2[i];
                }
                
                int[] mult_res = new int[split_a.Length];
                mult_res = split_a;
                return mult_res;
            }
            
           //Console.WriteLine(Karatsuba(arr1, arr1));
           
           */


        }
    }
}
