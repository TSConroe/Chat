using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net;

namespace Chat.ClientConsole
{
    class Program
    {
        private IPAddress Ip = null;
        int port = 0;

        public void CreateConfig()
        {
            // пока задаэм значеня в ручну для порта й Ip 
            string IpAndPort = "192.168.0.1:7770";

            try
            {
                DirectoryInfo data = new DirectoryInfo("Configuration");
                data.Create();

                var sw = new StreamWriter(@"Configuration/server.conf");
                sw.WriteLine(IpAndPort);
                sw.Close();
                Console.WriteLine("Adress {0} was add to config file succsessfully!!", IpAndPort);

            }
            catch (Exception exp)
            {
                Console.WriteLine(exp);
            }

        }

        public void ReadConfig() //провыряэм конфиг файл й витягуэм з ньго ип й порт
        {
            try
            {
                var sr = new StreamReader(@"Configuration/server.conf");
                string confbufer = sr.ReadToEnd();
                sr.Close();
                string[] connect_info = confbufer.Split(':');
                Ip = IPAddress.Parse(connect_info[0]);
                port = int.Parse(connect_info[1]);
                Console.WriteLine("Adress  and port from conf file:", connect_info[0]);
            }
            catch (DirectoryNotFoundException)
            {
                Console.WriteLine("ОШИБКА!!! Папка с конфигом не найдена");
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("ОШИБКА!!! Файл конфигурации не найден");
            }
            catch (Exception exp)
            {
                Console.WriteLine(exp);
            }



                
        }




        static void Main(string[] args)
        {
            Program ob = new Program();
            if (Directory.Exists(@"Configuration") || File.Exists(@"Configuration/server.conf"))
            {
                ob.ReadConfig();
                Console.WriteLine("Файл конфигурации найден! ");
            }

            else
            { 
            ob.CreateConfig();
            Console.WriteLine("Файл конфигурации не был найден, и потому создан новый ");
            }
        }
    }
}
