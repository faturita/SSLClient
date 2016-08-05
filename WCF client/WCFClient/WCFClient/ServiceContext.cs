using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using System.Net;
using System.Security.Principal;

namespace Bpf.Common.Service
{
    [Serializable]
    [DataContract]
    public class ServiceContext
    {
        public ServiceContext() 
        {
            CompanyId = 1;
            Culture = System.Globalization.CultureInfo.CurrentCulture.IetfLanguageTag;

            string hostName = Dns.GetHostName();
            IPAddress hostIPAddress1 = (Dns.Resolve(hostName)).AddressList[0];
            ClientIp = hostIPAddress1.ToString();
            UserName = WindowsIdentity.GetCurrent().Name;
            CompanyId = 1;
        }

        [DataMember]
        public string ClientIp { get; set; }
        [DataMember]
        public long CompanyId { get; set; }
        [DataMember]
        public string Culture { get; set; }
        [DataMember]
        public long HighCode { get; set; }
        [DataMember]
        public long MaxId { get; set; }
        [DataMember]
        public long OfficeId { get; set; }
        [DataMember]
        public long TerminalId { get; set; }
        [DataMember]
        public string TimeZone { get; set; }
        [DataMember]
        public long UserId { get; set; }
        [DataMember]
        public string UserName { get; set; }
    }
}
