using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Net;
using System.Text.RegularExpressions;
using System.Runtime.InteropServices;
using System.Web;
using System.Diagnostics;
using System.Threading;

namespace PHD_AutoSeed
{
    class PHDWatch
    {
        static string uid, login, pass, passkey, website;
        static string watch, torrents, download;
        static bool anonymous;
        StreamWriter sw_status;
        Thread p;
        Process cli;

        public PHDWatch()
        {
            cli = new Process();
        }

        [DllImport("kernel32")]
        private static extern long GetPrivateProfileString(string section, string key, string def, StringBuilder retVal, int size, string filePath);

        private int PostSeed(string filename, string text)
        {
            string boundary = "------------PHDAutoSeed--" + DateTime.Now.ToBinary();
            string fileField, textField;
            int count;
            MemoryStream postStream = new MemoryStream();
            byte[] buffer;
            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(website + "takeupload.php");
            request.Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,*/*;q=0.8";
            request.UserAgent = "Mozilla/4.0 (compatible; MSIE 8.0; Windows NT 6.0)";
            request.KeepAlive = true;
            request.ContentType = "multipart/form-data; boundary=" + boundary;
            request.CookieContainer = new CookieContainer();
            request.CookieContainer.Add(new Uri(website), new Cookie("c_secure_uid", uid));
            request.CookieContainer.Add(new Uri(website), new Cookie("c_secure_pass",pass));
            //request.CookieContainer.Add(new Uri("http://pt.phdbits.net"), new Cookie("c_secure_ssl","bm9wZQ%3D%3D"));
            //request.CookieContainer.Add(new Uri("http://pt.phdbits.net"), new Cookie("c_secure_tracker_ssl","bm9wZQ%3D%3D"));
            request.CookieContainer.Add(new Uri(website), new Cookie("c_secure_login", login));
            request.Method = "POST";
            request.AllowAutoRedirect = false;

            fileField = "--" + boundary + "\r\n" +
                        "Content-Disposition: form-data; name=\"file\"; filename=\"" +
                        filename + "\"\r\nContent-Type: application/x-bittorrent\r\n\r\n";
            buffer = Encoding.UTF8.GetBytes(fileField);
            postStream.Write(buffer, 0, buffer.Length);
            FileStream fs = new FileStream(Environment.CurrentDirectory+"\\tmp\\"+filename, FileMode.Open, FileAccess.Read);
            buffer = new byte[500000];
            do
            {
                count = fs.Read(buffer, 0, buffer.Length);
                postStream.Write(buffer, 0, count);
            } while (count > 0);
            fs.Close();
            buffer = Encoding.UTF8.GetBytes("\r\n");
            postStream.Write(buffer, 0, buffer.Length);


            string[] strArr = Regex.Split(text, "&");
            textField = "";
            foreach (string var in strArr)
            {
                Match M = Regex.Match(var, "([^=]+)=(.+)");
                textField += "--" + boundary + "\r\n";
                textField += "Content-Disposition: form-data; name=\"" + M.Groups[1].Value + "\"\r\n\r\n" + M.Groups[2].Value + "\r\n";
            }
            textField = textField.Replace("\\r\\n", "\r\n");
            Console.WriteLine(textField);
            //System.Windows.Forms.MessageBox.Show(textField);
            buffer = Encoding.UTF8.GetBytes(textField);
            postStream.Write(buffer, 0, buffer.Length);
            buffer = Encoding.UTF8.GetBytes("--" + boundary + "--\r\n");
            postStream.Write(buffer, 0, buffer.Length);

            postStream.Position = 0;

            buffer = new byte[100000000];
            count = postStream.Read(buffer, 0, buffer.Length);
            request.ContentLength = count;
            Stream sw = request.GetRequestStream();
            sw.Write(buffer, 0, count);
            sw.Close();
            postStream.Close();

            HttpWebResponse pos = (HttpWebResponse)request.GetResponse();

            switch(pos.StatusCode)
            {
                case HttpStatusCode.Found:
                    try
                    {
                        Match M = Regex.Match(pos.Headers["Location"], "(.+id)=(\\d*)");
                        return int.Parse(M.Groups[2].Value);
                    }
                    catch (Exception ee)
                    {
                        Log.WriteLog("Login Failed...maybe");
                        return -1;
                    }
                case HttpStatusCode.OK:
                    StreamReader sr = new StreamReader(pos.GetResponseStream());
                    Console.WriteLine(sr.ReadToEnd());
                    return -1;
                default:
                    Log.WriteLog(pos.StatusCode.ToString());
                    return -1;
            }
        }

        private string DownloadSeed(int id)
        {
            try
            {
                HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(website + "download.php?id=" + id.ToString());
                request.Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,*/*;q=0.8";
                //request.UserAgent = "Mozilla/5.0 (Windows NT 5.1) AppleWebKit/537.1 (KHTML, like Gecko) Chrome/21.0.1180.92 Safari/537.1 LBBROWSER";
                request.UserAgent = "Mozilla/4.0 (compatible; MSIE 8.0; Windows NT 6.0)";
                //request.
                request.KeepAlive = true;
                //request.ContentType
                request.CookieContainer = new CookieContainer();
                request.CookieContainer.Add(new Uri(website), new Cookie("c_secure_uid", uid));
                request.CookieContainer.Add(new Uri(website), new Cookie("c_secure_pass", pass));
                //request.CookieContainer.Add(new Uri("http://pt.phdbits.net"), new Cookie("pma_lang","zh_CN"));
                //request.CookieContainer.Add(new Uri("http://pt.phdbits.net"), new Cookie("pma_collation_connection","utf8_general_ci"));
                request.CookieContainer.Add(new Uri(website), new Cookie("c_secure_login", login));
                request.Method = "GET";
                request.AllowAutoRedirect = false;
                HttpWebResponse pos = (HttpWebResponse)request.GetResponse();

                foreach (string contentDisposition in pos.GetResponseHeader("Content-Disposition").Split(';'))
                {
                    int filenameIndex = contentDisposition.IndexOf("filename=", StringComparison.InvariantCulture);
                    if (filenameIndex >= 0)
                    {
                        string filename = contentDisposition.Substring(filenameIndex + 9, contentDisposition.Length - filenameIndex - 9);
                        filename = HttpUtility.UrlDecode(filename);
                        Stream input = pos.GetResponseStream();
                        if (false == Directory.Exists(Environment.CurrentDirectory + "\\torrents"))
                            Directory.CreateDirectory(Environment.CurrentDirectory + "\\torrents");
                        Stream output = File.OpenWrite(Environment.CurrentDirectory + "\\torrents\\" + filename);
                        byte[] buffer = new byte[5000];
                        int count;
                        do
                        {
                            count = input.Read(buffer, 0, 5000);
                            output.Write(buffer, 0, count);
                        } while (count > 0);

                        input.Close();
                        output.Close();
                        return filename;
                    }
                }
                return "";
                
            }
            catch (Exception ee)
            {
                Log.WriteLog(ee.Message);
                return "";
            }
 
        }

        private string MakeTorrent(string foldername,string folderpath) 
        {
            
            cli.StartInfo.FileName = Environment.CurrentDirectory + "\\transmission-create.exe";
            if (false == Directory.Exists(Environment.CurrentDirectory + "\\tmp"))
                Directory.CreateDirectory(Environment.CurrentDirectory + "\\tmp");
            cli.StartInfo.Arguments = "-t " + website + "annouce.php -c PHD -p \"" + folderpath + "\\" + foldername + "\" -o \"" + Environment.CurrentDirectory + "\\tmp\\" + foldername + ".torrent\"";
            cli.StartInfo.WorkingDirectory = Environment.CurrentDirectory + "\\tmp";
            cli.StartInfo.UseShellExecute = false;
            cli.StartInfo.CreateNoWindow = true;
            cli.Start();
            cli.WaitForExit();
            return foldername + ".torrent";
        }

        public static void LoadConfig()
        {
            if (File.Exists("config.ini"))
            {
                StringBuilder sb = new StringBuilder(65535);
                GetPrivateProfileString("Cookies", "c_secure_uid", "", sb, 65535, Environment.CurrentDirectory + "\\config.ini");
                uid = sb.ToString();
                GetPrivateProfileString("Cookies", "c_secure_login", "", sb, 65535, Environment.CurrentDirectory + "\\config.ini");
                login = sb.ToString();
                GetPrivateProfileString("Cookies", "c_secure_pass", "", sb, 65535, Environment.CurrentDirectory + "\\config.ini");
                pass = sb.ToString();
                GetPrivateProfileString("Cookies", "website", "", sb, 65535, Environment.CurrentDirectory + "\\config.ini");
                website = sb.ToString();
                if (website.LastIndexOf('/') != website.Length - 1)
                    website = website + "/";
                GetPrivateProfileString("Cookies", "anonymous", "", sb, 65535, Environment.CurrentDirectory + "\\config.ini");
                if (sb.ToString() == "1")
                    anonymous = true;
                else
                    anonymous = false;
                //GetPrivateProfileString("Torrents", "passkey", "", sb, 65535, Environment.CurrentDirectory + "\\config.ini");
                //passkey = sb.ToString();
                GetPrivateProfileString("Torrents", "watch", "", sb, 65535, Environment.CurrentDirectory + "\\config.ini");
                watch = sb.ToString();
                GetPrivateProfileString("Torrents", "torrents", "", sb, 65535, Environment.CurrentDirectory + "\\config.ini");
                torrents = sb.ToString();
                GetPrivateProfileString("Torrents", "download", "", sb, 65535, Environment.CurrentDirectory + "\\config.ini");
                download = sb.ToString();
            }
            else
                Log.WriteLog("cofing.ini WAS No FOUND");
        }

        private void Watch()
        {
            LoadConfig();
            string filename = "";
            while (true)
            {
                try
                {
                    foreach (string folder in watch.Split(';'))
                    {
                        if (Directory.Exists(folder) == false)
                            continue;
                        DirectoryInfo parent = new DirectoryInfo(folder);
                        foreach (DirectoryInfo child in parent.GetDirectories())
                        {
                            if (child.Name.IndexOf("===DONE") > 0)
                            {
                                string name = child.Name.Remove(child.Name.IndexOf("===DONE"));
                                string fullname = child.FullName.Remove(child.FullName.IndexOf("===DONE"));
                                Directory.Move(child.Parent.FullName + "\\" + child.Name, child.Parent.FullName + "\\" + name);
                                Mark(fullname, "ToMakeTorrent", "");
                                string torrentname = MakeTorrent(name, child.Parent.FullName);
                                if (File.Exists(Environment.CurrentDirectory + "\\tmp\\" + torrentname))
                                    Mark(fullname, "ToPost", torrentname);
                                int torrentid = PostSeed(torrentname, GenPostForm(name, fullname + "\\" + name + ".nfo"));
                                if (torrentid > 0)
                                {
                                    Mark(fullname, "ToDownload", torrentid.ToString());
                                    filename = DownloadSeed(torrentid);
                                    if (File.Exists(Environment.CurrentDirectory + "\\torrents\\" + filename))
                                    {
                                        Mark(fullname, "ToSeed", filename);
                                        if (false == Directory.Exists(download + "\\" + name))
                                            Directory.Move(fullname, download + "\\" + name);
                                        File.Move(Environment.CurrentDirectory + "\\torrents\\" + filename, torrents + "\\" + filename);
                                        File.Delete(fullname + ".status");
                                    }
                                }
                            }
                            if (File.Exists(child.FullName+".status"))
                            {
                                StreamReader sr = new StreamReader(child.FullName + ".status");
                                string status = sr.ReadLine();

                                switch (status)
                                {
                                    case "ToMakeTorrent":
                                        sr.Close();
                                        string torrentname = MakeTorrent(child.Name, child.Parent.FullName);
                                        if (File.Exists(Environment.CurrentDirectory + "\\tmp\\" + torrentname))
                                            Mark(child.FullName, "ToPost", torrentname);
                                        break;
                                    case "ToPost":
                                        int torrentid = PostSeed(sr.ReadLine(), GenPostForm(child.Name,child.FullName+"\\"+child.Name+".nfo"));
                                        sr.Close();
                                        if (torrentid > 0)
                                            Mark(child.FullName, "ToDownload", torrentid.ToString());
                                        break;
                                    case "ToDownload":
                                        filename = DownloadSeed(int.Parse(sr.ReadLine()));
                                        sr.Close();
                                        if (File.Exists(Environment.CurrentDirectory + "\\torrents\\" + filename))
                                            Mark(child.FullName, "ToSeed", filename);
                                        break;
                                    case "ToSeed":
                                        filename = sr.ReadLine();
                                        sr.Close();
                                        if (File.Exists(Environment.CurrentDirectory + "\\torrents\\" + filename))
                                        {
                                            Mark(child.FullName, "ToSeed", filename);
                                            if (false == Directory.Exists(download + "\\" + child.Name))
                                                Directory.Move(child.FullName, download + "\\" + child.Name);
                                            File.Move(Environment.CurrentDirectory + "\\torrents\\" + filename, torrents + "\\" + filename);
                                            File.Delete(child.FullName + ".status");
                                        }
                                        break;
                                    default:
                                        sr.Close();
                                        File.Delete(child.FullName + ".status");
                                        break;

                                }
                            }
                        }
                        
                    }
                }
                catch (Exception ee)
                {
                    Console.WriteLine(ee.Message);
                    Log.WriteLog(ee.Message);
                }
                Thread.Sleep(new TimeSpan(0,0,1));
            }
        }

        public string Start()
        {
            if (p != null)
                return "Running";
            p = new Thread(new ThreadStart(Watch));
            p.Start();
            return "Success";
        }
        public string Quit()
        {
            if (p == null)
                return "DONE";
            p.Abort();
            p.Join();
            p = null;
            try
            {
                cli.Kill();
            }
            catch (Exception ee)
            {
                Console.WriteLine(ee.Message);
            }

            return "DONE";
        }

        private void Mark(string folderfullname, string status, string value)
        {
            DirectoryInfo folder = new DirectoryInfo(folderfullname);
            StreamWriter sw = new StreamWriter(folder.FullName + ".STATUS",false);
            sw.WriteLine(status);
            sw.WriteLine(value);
            sw.Close();
        }

        private string GenPostForm(string seedname, string nfofile)
        {
            


            string data = "";
            Dictionary<string, string> dic = new Dictionary<string, string>();

            string desrc = "[quote][color=Indigo][size=4] [b]您的保种是PT站长久发展的重要保证！只要片子在硬盘上不删，请自觉做到开机即做种！自觉保种可使资源的有效期无限延长、下载速度达到极限，同时也可以为你赚得上传流量和魔力值。方便你我他~感谢您对PHDbits的支持~[/color][/b][em23] [/quote][quote][color=Indigo][size=4] [b]AUTOSEED自动发种，待编辑~[/color][/b][em23] [/quote]";
            if (File.Exists(nfofile))
            {

                try
                {
                    desrc += "[code]\\r\\n";
                    string[] lines = File.ReadAllLines(nfofile);
                    int i = 0;
                    while (lines[i].IndexOf("+-------------+") < 0) i++;
                    if (lines[i + 1].IndexOf("TV") > 0) dic.Add("type", "402");
                    if (lines[i + 1].IndexOf("Movie") > 0) dic.Add("type", "401");
                    while (lines[i + 1].IndexOf("For more info,") < 0)
                    {
                        desrc += lines[i] + "\\r\\n";
                        i++;
                    }
                    desrc += "[/code]";
                    Console.WriteLine(desrc);
                }
                catch (Exception ee)
                {
                    Log.WriteLog(ee.Message);
                }

            }
            else
                dic.Add("type", "402");

            dic.Add("name", seedname.Replace('.', ' '));
            dic.Add("small_descr", "[PHD作品][内置中字]");
            dic.Add("descr", desrc);
            
            dic.Add("medium_sel", "7");
            dic.Add("codec_sel", "1");
            dic.Add("standard_sel", "3");
            dic.Add("team_sel", "1");
            if (anonymous)
                dic.Add("uplver", "yes");
            else
                dic.Add("uplver", "no");


            foreach (KeyValuePair<string, string> pair in dic)
            {
                data += pair.Key + "=" + pair.Value + "&";
            }
            data = data.Remove(data.LastIndexOf("&"));

            Console.WriteLine(data);
            return data;


        }

   
    }
}
