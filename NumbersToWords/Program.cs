using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Core;
using System;
using System.Linq;

namespace numsToWords
{
    class NumsToWords
    {
        static void Main(string[] args)
        {
            string isNeg = "";
            try
            {
                Console.WriteLine("Enter a number to convert to currency (Decimals separated by comma)");
                string num = Console.ReadLine();
                num = Convert.ToDouble(num).ToString();

                if (num.Contains("-"))
                {
                    isNeg = "Minus ";
                    num = num.Substring(1, num.Length - 1);
                }
                if (num == "0")
                {
                    Console.WriteLine("The number in currency fomat is \nZero rand");
                }
                else
                {
                    Console.WriteLine("The number in currency fomat is \n{0}", isNeg + NumberToWords(num));
                }
                Console.ReadKey();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private static String ones(String num)
        {
            int _num = Convert.ToInt32(num);
            String name = "";
            switch (_num)
            {

                case 1:
                    name = "One";
                    break;
                case 2:
                    name = "Two";
                    break;
                case 3:
                    name = "Three";
                    break;
                case 4:
                    name = "Four";
                    break;
                case 5:
                    name = "Five";
                    break;
                case 6:
                    name = "Six";
                    break;
                case 7:
                    name = "Seven";
                    break;
                case 8:
                    name = "Eight";
                    break;
                case 9:
                    name = "Nine";
                    break;
            }
            return name;
        }

        private static String tens(String num)
        {
            int _num = Convert.ToInt32(num);
            String name = null;
            switch (_num)
            {
                case 10:
                    name = "Ten";
                    break;
                case 11:
                    name = "Eleven";
                    break;
                case 12:
                    name = "Twelve";
                    break;
                case 13:
                    name = "Thirteen";
                    break;
                case 14:
                    name = "Fourteen";
                    break;
                case 15:
                    name = "Fifteen";
                    break;
                case 16:
                    name = "Sixteen";
                    break;
                case 17:
                    name = "Seventeen";
                    break;
                case 18:
                    name = "Eighteen";
                    break;
                case 19:
                    name = "Nineteen";
                    break;
                case 20:
                    name = "Twenty";
                    break;
                case 30:
                    name = "Thirty";
                    break;
                case 40:
                    name = "Fourty";
                    break;
                case 50:
                    name = "Fifty";
                    break;
                case 60:
                    name = "Sixty";
                    break;
                case 70:
                    name = "Seventy";
                    break;
                case 80:
                    name = "Eighty";
                    break;
                case 90:
                    name = "Ninety";
                    break;
                default:
                    if (_num > 0)
                    {
                        name = tens(num.Substring(0, 1) + "0") + " " + ones(num.Substring(1));
                    }
                    break;
            }
            return name;
        }

        private static String ConvertWholeNum(String num)
        {
            string word = "";
            try
            {
                bool beginsZero = false;
                bool isDone = false;
                double dblAmt = (Convert.ToDouble(num));
                if (dblAmt > 0)
                {  
                    beginsZero = num.StartsWith("0");

                    int numDigits = num.Length;
                    int pos = 0; 
                    String place = "";    
                    switch (numDigits)
                    {
                        case 1:

                            word = ones(num);
                            isDone = true;
                            break;
                        case 2:
                            word = tens(num);
                            isDone = true;
                            break;
                        case 3:
                            pos = (numDigits % 3) + 1;
                            place = " Hundred ";
                            break;
                        case 4:
                        case 5:
                        case 6:
                            pos = (numDigits % 4) + 1;
                            place = " Thousand ";
                            break;
                        case 7:
                        case 8:
                        case 9:
                            pos = (numDigits % 7) + 1;
                            place = " Million ";
                            break;
                        case 10:
                        case 11:
                        case 12:

                            pos = (numDigits % 10) + 1;
                            place = " Billion ";
                            break;
                        default:
                            isDone = true;
                            break;
                    }
                    if (!isDone)
                    {
                        if (num.Substring(0, pos) != "0" && num.Substring(pos) != "0")
                        {
                            try
                            {
                                word = ConvertWholeNum(num.Substring(0, pos)) + place + ConvertWholeNum(num.Substring(pos));
                            }
                            catch { }
                        }
                        else
                        {
                            word = ConvertWholeNum(num.Substring(0, pos)) + ConvertWholeNum(num.Substring(pos));
                        }    
                    }
                    if (word.Trim().Equals(place.Trim())) word = "";
                }
            }
            catch { }
            return word.Trim();
        }

        private static String NumberToWords(String numb)
        {
            String val = "", wholeNo = numb, points = "", andStr = "", pointStr = "";
            String endStr = "";
            try
            {
                int dec = numb.IndexOf(',');
                if (dec > 0)
                {
                    wholeNo = numb.Substring(0, dec);
                    points = numb.Substring(dec + 1);
                    if (Convert.ToInt32(points) > 0)
                    {
                        andStr = "Rands and";    
                        endStr = "Cents " + endStr;  
                        pointStr = ConvertDec(points);
                    }
                }
                val = String.Format("{0} {1}{2} {3}", ConvertWholeNum(wholeNo).Trim(), andStr, pointStr, endStr);
            }
            catch { }
            return val;
        }

        private static String ConvertDec(String num)
        {
            String cd = "", digit = "", engOne = "";
            for (int i = 0; i < num.Length; i++)
            {
                digit = num[i].ToString();
                if (digit.Equals("0"))
                {
                    engOne = "Zero";
                }
                else
                {
                    engOne = ones(digit);
                }
                cd += " " + engOne;
            }
            return cd;
        }
    }
}
