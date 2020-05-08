using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using System.IO;
using EAGetMail;

namespace JiraAssignment.FeatureSteps
{
    class gmail
    {


        public string gmail_test(string Email, string Password, bool check)
        {
            string Url = null;
            try
            {

                MailServer oServer = new MailServer("imap.gmail.com",
                                Email,
                                Password,
                                ServerProtocol.Imap4);

                // Enable SSL connection.
                oServer.SSLConnection = true;

                // Set 993 SSL port
                oServer.Port = 993;

                MailClient oClient = new MailClient("TryIt");
                oClient.Connect(oServer);

                // retrieve unread/new email only
                oClient.GetMailInfosParam.Reset();
                oClient.GetMailInfosParam.GetMailInfosOptions = GetMailInfosOptionType.NewOnly;

                MailInfo[] infos = oClient.GetMailInfos();
                Console.WriteLine("Total {0} unread email(s)\r\n", infos.Length);
                for (int i = 0; i < infos.Length; i++)
                {
                    MailInfo info = infos[i];
                    Console.WriteLine("Index: {0}; Size: {1}; UIDL: {2}",
                        info.Index, info.Size, info.UIDL);

                    // Receive email from IMAP4 server
                    Mail oMail = oClient.GetMail(info);

                    Console.WriteLine("From: {0}", oMail.From.ToString());
                    Console.WriteLine("Subject: {0}\r\n ", oMail.Subject);

                    if(oMail.Subject.Contains("[JIRA] Account created"))
                    {
                        Url  = ((oMail.HtmlBody.Split(new string[] { "margin: 0px\"> <a href=\"" }, StringSplitOptions.None))[1].Split(new string[] { "\" class=\"aui-button-email-link\"" }, StringSplitOptions.None))[0].Replace("amp;", "");
                        //Console.WriteLine(Url);
                        // mark unread email as read, next time this email won't be retrieved again
                        if (!info.Read)
                        {
                            oClient.MarkAsRead(info, check);
                        }
                        break;
                    }


                    
                }

                // Quit and expunge emails marked as deleted from IMAP4 server.
                oClient.Quit();
                Console.WriteLine("Completed!");
                
            }
            catch (Exception ep)
            {
                Console.WriteLine(ep.Message);
            }
            return Url;
        }
    }
}
