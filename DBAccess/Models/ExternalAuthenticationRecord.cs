using System;
using System.Collections.Generic;

#nullable disable

namespace DBAccess.Models
{
    public partial class ExternalAuthenticationRecord
    {
        public Guid Id { get; set; }
        public string OpenId { get; set; }
        public Guid UserId { get; set; }
        public string ProviderSystemName { get; set; }
    }
}
