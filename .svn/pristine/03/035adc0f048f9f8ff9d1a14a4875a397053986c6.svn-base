using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ERP
{
    class WordCase
    {
        public static  string WordSet(string word)
        {
            string returnword = "";
            if (word.Length > 0)
            {
                string[] w = word.Split(' ');
                foreach (string wrd in w)
                {
                    if (wrd.Length > 0)
                    {
                        if (wrd.Substring(0, 1) == "'") returnword += wrd.ToUpper();
                        else
                        {
                            returnword += wrd.Substring(0, 1).ToUpper();
                            returnword += wrd.Substring(1, wrd.Length - 1).ToLower();
                        }

                    }
                    returnword += " ";
                }
                returnword= returnword.Substring(0, returnword.Length - 1);
            }
            return returnword;
        }
    }
}
