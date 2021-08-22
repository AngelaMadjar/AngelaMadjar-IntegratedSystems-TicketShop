using System;
using System.Collections.Generic;
using System.Text;

namespace _181010_IS_Homework1.Domain
{
    public class EmailSettings
    {
        public String SmtpServer { get; set; } // server's url
        public String  SmtpUserName { get; set; } // account which is configured to send smtp
        public String SmtpPassword { get; set; }
        public int SmtpServerPort { get; set; }
        public bool EnableSsl { get; set; }
        public String EmailDisplayName { get; set; }
        public String SenderName { get; set; }

        public EmailSettings() { }

        public EmailSettings(String SmtpServer, String SmtpUserName, String SmtpPassword, 
            int SmtpServerPort, bool EnableSsl, String EmailDisplayName, String SenderName)
        {
            this.SmtpServer = SmtpServer;
            this.SmtpUserName = SmtpUserName;
            this.SmtpPassword = SmtpPassword;
            this.SmtpServerPort = SmtpServerPort;
            this.EnableSsl = EnableSsl;
            this.EmailDisplayName = EmailDisplayName;
            this.SenderName = SenderName;
        }
    }
}
