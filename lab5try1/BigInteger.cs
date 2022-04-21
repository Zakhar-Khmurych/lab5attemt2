



using System;
using System.Linq;

namespace lab5try1
{
    public class BigInteger
    {
        private bool _is_negative = false;

        private int[] _numbers;

        private string _numbersString;
                
        public BigInteger(string value)
        {
            char[] characters = value.ToCharArray();
            int i = 0;

            _numbers = new int[value.Length];

            foreach (var symbol in characters)
            {
                _numbers[i] = Convert.ToByte(symbol) - 48;
                i += 1;
            }

            _numbersString = "";

            for (int j = 0; j < _numbers.Length; j++)
            {
                _numbersString += Convert.ToString(_numbers[j]);
            }
        }

        public override string ToString()
        {            
            if (_is_negative)
            {
                _numbersString = "-" + _numbersString;
            }
            return _numbersString;
        }

        public BigInteger Add(BigInteger another)
        {

            int maxLength = this._numbers.Length;
            int minLength = another._numbers.Length;

            int[] num1Copy;
            int[] num2Copy;

            if (this._numbers.Length < another._numbers.Length)
            {
                maxLength = another._numbers.Length;
                minLength = this._numbers.Length;

            }

            num1Copy = new int[maxLength];
            num2Copy = new int[maxLength];


            for (int i = this._numbers.Length - 1; i >= 0; i--)
            {
                num1Copy[i + maxLength - this._numbers.Length] = this._numbers[i];
            }

            for (int i = another._numbers.Length - 1; i >= 0; i--)
            {
                num2Copy[i + maxLength - another._numbers.Length] = another._numbers[i];
            }

            int[] sum;
            sum = new int[maxLength + 1];

            for (int i = maxLength - 1; i >= 0; i--)
            {
                sum[i + 1] += num1Copy[i] + num2Copy[i];
            }

            for (int i = sum.Length - 1; i > -1; i--)
            {
                if (sum[i] >= 10)
                {
                    sum[i] = sum[i] % 10;
                    sum[i - 1] = sum[i - 1] + 1;

                }
            }

            string s = "";

            if (((sum[0] == 0) && (sum.Length > 1)))
            {
                for (int i = 1; i < sum.Length; i++)
                {
                    s += sum[i];
                }
            }
            else
            {
                for (int i = 0; i < sum.Length; i++)
                {
                    s += sum[i];
                }
            }

            BigInteger result = new BigInteger(s);
            return result;
        }


        public BigInteger Sub(BigInteger another)
        {
            bool isNegative = false;
            int maxLength = this._numbers.Length;
            int minLength = another._numbers.Length;

            if (this._numbers.Length < another._numbers.Length)
            {
                maxLength = another._numbers.Length;
                minLength = this._numbers.Length;
                isNegative = true;
            }

            int[] num1Copy;
            int[] num2Copy;

            num1Copy = new int[maxLength];
            num2Copy = new int[maxLength];


            for (int i = this._numbers.Length - 1; i >= 0; i--)
            {
                num1Copy[i + maxLength - this._numbers.Length] = this._numbers[i];
            }

            for (int i = another._numbers.Length - 1; i >= 0; i--)
            {
                num2Copy[i + maxLength - another._numbers.Length] = another._numbers[i];
            }

            int[] diff;
            diff = new int[maxLength];
            string sub_result = "";
            bool leadingZero = true;


            if (this._numbers.Length > another._numbers.Length)
            {
                for (int i = 0; i < diff.Length; i++)
                {
                    diff[i] = num1Copy[i] - num2Copy[i];
                    if (diff[i] < 0)
                    {
                        diff[i] += 10;
                        diff[i - 1] += -1;
                    }
                }
            }
            else if (this._numbers.Length < another._numbers.Length)
            {
                for (int i = 0; i < diff.Length; i++)
                {
                    diff[i] = num2Copy[i] - num1Copy[i];
                    if (diff[i] < 0)
                    {
                        diff[i] += 10;
                        diff[i - 1] += -1;
                    }
                }
            }
            else
            {
                for (int i = 0; i < diff.Length; i++)
                {
                    diff[i] = num1Copy[i] - num2Copy[i];
                }
            }

            int start_point = 0;

            for (int i = 0; i < diff.Length; i++)
            {
                if (diff[i] != 0)
                {
                    start_point = i;
                    break;
                }
                else if (i == diff.Length - 1)
                {
                    start_point = i;
                    isNegative = false;
                }
            }


            for (int i = start_point; i < diff.Length; i++)
            {
                if (diff[i] >= 0)
                {
                    sub_result += diff[i];
                }
                else
                {
                    sub_result += diff[i] * -1;
                    isNegative = true;
                }
            }

            BigInteger result = new BigInteger(sub_result);
            result._is_negative = isNegative;
            return result;
        }

        
        public static BigInteger operator +(BigInteger a, BigInteger b) => a.Add(b); 
        public static BigInteger operator -(BigInteger a, BigInteger b) => a.Sub(b); 
        public static BigInteger operator *(BigInteger a, BigInteger b) => a.Karatsuba(b); 
        
        public BigInteger Karatsuba(BigInteger another)
        {
            // from Wikipedia
            // https://en.wikipedia.org/wiki/Karatsuba_algorithm

            BigInteger result;

            int len;

            if (this._numbers.Length > another._numbers.Length)
            {
                len = this._numbers.Length;
            }
            else
            {
                len = another._numbers.Length;
            }


            string leadingZero = "";
            for (int i = 0; i < len - this._numbers.Length; i++)
            {
                leadingZero = leadingZero + "0";

            }
            leadingZero = leadingZero + this._numbersString;
            BigInteger x = new BigInteger(leadingZero);
        

            leadingZero = "";
            for (int i = 0; i < len - this._numbers.Length; i++)
            {
                leadingZero = leadingZero + "0";

            }
            leadingZero = leadingZero + another._numbersString;
            BigInteger y = new BigInteger(leadingZero);


            if (len == 1)
            {
                result = new BigInteger(Convert.ToString(this._numbers[0] * another._numbers[0]));
            }
            else
            {

    
                BigInteger a = new BigInteger(x._numbersString.Substring(0, len/2));
                BigInteger b = new BigInteger(x._numbersString.Substring(len/2));


                BigInteger c = new BigInteger(y._numbersString.Substring(0, len/2));
                BigInteger d = new BigInteger(y._numbersString.Substring(len/2));

                BigInteger p0 = b.Karatsuba(d);
                BigInteger p1 = (a.Add(b)).Karatsuba(c.Add(d));
                BigInteger p2 = a.Karatsuba(c);
                
                
                BigInteger s2 = new BigInteger(p2._numbersString + Ten2n(len));
                BigInteger s0 = p1.Sub(p2).Sub(p0);
                BigInteger s1 = new BigInteger(s0._numbersString + Ten2n(len/2));

                
                result = s2.Add(s1).Add(p0);
              
            }
            return result;

            string Ten2n(int n)
            {
                string result = "";
                for (int i = 1; i <= n; i++)
                {
                    result = result + "0";
                }
                return result;
            }
        }

    }
}