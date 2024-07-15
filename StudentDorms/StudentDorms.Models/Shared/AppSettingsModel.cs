using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentDorms.Models.Shared
{
    public class AppSettingsModel
    {
        public string ApiUrl { get; set; }

        public string SmtpServer { get; set; }

        public string SmtpAddressFrom { get; set; }

        public bool EnableSmtpAuthentication { get; set; }

        public string SmtpServerUserName { get; set; }

        public string SmtpServerPassword { get; set; }

        public int SmtpServerPort { get; set; }

        public string DbConnectionString { get; set; }

        public string LdapPath { get; set; }

        public string DomainNameToken { get; set; }

        public string ClaimsToken { get; set; }
    }

    public class AppSettingsSharedModel
    {
        public AppSettingsModel appSettings { get; set; }

        public string refreshTokenUrl { get; set; }
    }
}
