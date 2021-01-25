using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SQLite;
using System.IO;

namespace ConsoleApp1
{
    class HaiwellProj
    {
        private static readonly string dbpassword;

        static HaiwellProj()
        {
            HaiwellProj.dbpassword = "$HW@gZ25dzv*u0.nT$bhBl5!eFbS";
        }
        public static bool Haiwellencrypt(string sqliteFile, bool flag)
        {
            SQLiteConnection cnn = new SQLiteConnection("Data Source=" + sqliteFile + ";Version = 3;Password=" + HaiwellProj.dbpassword);
            bool result;
            try
            {
                cnn.Open();
                if (!flag)
                {
                    cnn.ChangePassword("");
                }
                else
                {
                    cnn.ChangePassword(HaiwellProj.dbpassword);
                }
                cnn.Close();
                result = true;
            }
            catch
            {
                cnn.Close();
                cnn = new SQLiteConnection("Data Source=" + sqliteFile + ";Version = 3;");
                try
                {
                    cnn.Open();
                    if (flag)
                    {
                        cnn.ChangePassword(HaiwellProj.dbpassword);
                    }
                    result = true;
                }
                catch
                {
                    cnn.Close();
                    result = false;
                }
            }
            finally
            {
                cnn.Close();
            }
            return result;

        }
        static void Main(string[] args)
        {

            if (args.Length < 2)
            {
                Console.WriteLine("参数不正确");
                return;
            }
            if (!File.Exists(args[1]))
            {
                Console.WriteLine("文件不存在");
                return;
            }
            if (args[0] == "-e")
            {
                HaiwellProj.Haiwellencrypt(args[1], true);
                Console.WriteLine("加密成功");
            }
            if (args[0] == "-d")
            {
                HaiwellProj.Haiwellencrypt(args[1], false);
                Console.WriteLine("解密成功");
            }

        }
    }
}

