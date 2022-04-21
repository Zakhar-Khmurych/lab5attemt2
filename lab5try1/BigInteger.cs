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
                _numbers[i] = Convert.ToByte(symbol)-48;
                i += 1;
            }
        }

        public override string ToString()
        {
            _numbersString = "";
            if (_is_negative)
            {
                _numbersString += "-";
            }
            
            for (int i = 0; i < _numbers.Length; i++)
            {
                _numbersString += Convert.ToString(_numbers[i]);
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
            

            for (int i = this._numbers.Length-1; i >=0; i--)
            {
                num1Copy[i+maxLength-this._numbers.Length] = this._numbers[i];
            }

            for (int i = another._numbers.Length-1; i >=0; i--)
            {
                num2Copy[i+maxLength-another._numbers.Length] = another._numbers[i];
            }
            
            int[] sum;
            sum = new int[maxLength+1];

            for (int i = maxLength-1; i >=0; i--)
            {
                sum[i+1] += num1Copy[i] + num2Copy[i];
            }

            for (int i = sum.Length-1; i > -1; i--)
            {
                if (sum[i] >= 10)
                {
                    sum[i] = sum[i] % 10;
                    sum[i-1] = sum[i-1] + 1;
                    
                }
            }
            
            string s ="";

            if (((sum[0] == 0) && (sum.Length>1)))
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
            bool isNegative=false;
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


            for (int i = this._numbers.Length-1; i >=0; i--)
            {
                num1Copy[i + maxLength - this._numbers.Length] = this._numbers[i];
            }

            for (int i = another._numbers.Length - 1; i>=0; i--)
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
                else if(i==diff.Length-1)
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
                    sub_result += diff[i]*-1;
                    isNegative = true;
                }
            }

            BigInteger result = new BigInteger(sub_result); 
            result._is_negative = isNegative;
            return result;
        }


        public BigInteger Mult(BigInteger another)
        {
            /*
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
            */
            
           // BigInteger result = new BigInteger(Convert.ToString(Karatsuba(this, another)));
           return null;
        }

        public BigInteger Karatsuba(BigInteger another)
        {
            BigInteger result;

            int len = this._numbers.Length;
            
            if (len == 1) 
            {
                result = new BigInteger(Convert.ToString(this._numbers[0]*another._numbers[0]));
            }
            else
            {
                /*
                int[] a = new int[len/2];
                int[] b = new int[len/2];
                int[] c = new int[len/2];
                int[] d = new int[len/2];
                
                
                for (int i = 0; i < len/2; i++)
                {
                    a[i] = x._numbers[i];
                    c[i] = y._numbers[i];
                }
                for (int i = len/2; i < len-len/2; i++)
                {
                    b[i] = x._numbers[i];
                    d[i] = y._numbers[i];
                } */

                BigInteger a = new BigInteger(this._numbersString.Substring(0, len/2));
                BigInteger b = new BigInteger(this._numbersString.Substring(len/2+1));
                BigInteger c = new BigInteger(another._numbersString.Substring(0, len/2));
                BigInteger d = new BigInteger(another._numbersString.Substring(len/2+1));

                BigInteger p0 = b.Karatsuba(d);
                BigInteger p1 = a.Add(b).Karatsuba(c.Add(d)); 
                BigInteger p2 = c.Karatsuba(c);

                /*
                BigInteger s2 = Karatsuba(p2, new BigInteger(Convert.ToString(Math.Pow(10, len))));
                BigInteger s1 = Karatsuba(p1.Sub(p2).Sub(p0), new BigInteger(Convert.ToString(Math.Pow(10, len/2))));
*/
                BigInteger s2 = p2.Karatsuba(new BigInteger("00100"));
                BigInteger s1 = p1.Sub(p2).Sub(p0).Karatsuba(new BigInteger("00010"));
                
                result = new BigInteger(Convert.ToString(s2.Add(s1).Add(p0)));

                // result = new BigInteger(Convert.ToString(p2*Math.Pow(10, len)));
                //(z2 × 10 ^ (m2 × 2)) + ((z1 - z2 - z0) × 10 ^ m2) + z0
            }
            return result;
        }

    }
}