using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net;

namespace Chat.ServerConsole
{
    class Program
    {
        private IPAddress Ip = null;
        int port = 0;

        public void CreateConfig()
        {
            // пока задаэм значеня в ручну для порта й Ip
           string IpAndPort ="192.168.0.1:7770";
                           
            try
            {
                DirectoryInfo data = new DirectoryInfo("Configuration");
                data.Create();

                var sw = new StreamWriter(@"Configuration/server.conf");
                sw.WriteLine(IpAndPort);
                sw.Close();
                
            }
            catch (Exception exp) {
                Console.WriteLine(exp);
            }

        }

        public void ReadConfig()
        {
            try
            {
                var sr = new StreamReader(@"Configuration/server.conf");
                string confbufer = sr.ReadToEnd();
                sr.Close();
                string[] connect_info = confbufer.Split(':');
                Ip = IPAddress.Parse(connect_info[0]);
                port = int.Parse(connect_info[1]);
            }
            catch { }

        }




        static void Main(string[] args)
        {
            
        }
    }
}
