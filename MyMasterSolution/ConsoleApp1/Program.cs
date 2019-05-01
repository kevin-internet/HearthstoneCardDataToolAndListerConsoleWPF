using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            string m_Path = "../HsDataRip.txt";
            string m_item = "";


            if (!File.Exists(m_Path))
            {
                throw new System.Exception("File: " + m_Path + " does not exist");
            }

            //FileStream fileStream = new FileStream(m_Path, FileMode.Open, FileAccess.Read, FileShare.Read, 64 * 1024,
            //(FileOptions)0x20000000 | FileOptions.WriteThrough & FileOptions.SequentialScan);

            FileStream fs2 = new FileStream(m_Path, FileMode.Open);

            using (StreamReader fs = new StreamReader(fs2))
            {
                m_item = fs.ReadToEnd();
            }


            Char[] characters = m_item.ToCharArray();

            List<string> itemslist = new List<string>();


            string tmp = "";
            int Left1 = 0;
            int Left2 = 0;
            
            for (int i = 0; i < m_item.Length; i++)
            {
                if (m_item[i] == '<')
                    Left2 = i + 1;
                if (m_item[i] == '>')
                {
                    tmp = m_item.Substring(Left2, i - Left2);
                    if (tmp.Contains("hearthstonejson.com/v1/tiles/"))
                    {
                        int start = tmp.IndexOf("hearthstonejson.com/v1/tiles/") + "hearthstonejson.com/v1/tiles/".Length;

                        string exitstr = tmp.Substring(start, 7);


                    }
                }



                if (m_item[i] == '>')
                    Left1 = i+1;
                if (m_item[i] == '<')
                {
                    tmp = m_item.Substring(Left1, i - Left1);
                    
                    
                        if (!(tmp == "" || tmp == "★" || tmp == "\r\n"))
                            itemslist.Add(tmp);
                        tmp = "";
                    
                }


            }



            //itemslist.RemoveAt(0);







        }
    }
}
