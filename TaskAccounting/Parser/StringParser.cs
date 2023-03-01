using System;

namespace TaskAccounting.Parser
{
    class StringParser
    {
        public static string LongSpaceToNewLine(string strIn)
        {
            string str = strIn;
            int i = 0;
            if (str[i] == ' ')
            {
                int j = i + 1;
                for (; j < str.Length; j++)
                {
                    if (str[j] != ' ')
                    {
                        break;
                    }
                }
                if (j - i > 3)
                {
                    str = str.Remove(i, j - i);
                    i = j;
                }
            }

            for (; i < str.Length - 5; i++)
            {
                if (str[i] == ' ')
                {
                    int j = i + 1;
                    for (; j < str.Length; j++)
                    {
                        if (str[j] != ' ')
                        {
                            break;
                        }
                    }
                    if (j - i > 3)
                    {
                        str = str.Remove(i, j - i);
                        str = str.Insert(i, '\n'.ToString());
                        i = j;
                    }
                }
            }

            return str;
        }

        public static string CombineBySeparator(string str1, string str2, char sep)
        {
            if(str1==null|str2==null)
            {
                
            }
            return str1 + sep + str2;
        }
    }
}
