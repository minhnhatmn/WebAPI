using System;
using System.Collections.Generic;

#nullable disable

namespace WebAPI.EF
{
    public partial class MessageSeen
    {
        public int IdUser { get; set; }
        public int IdMessage { get; set; }

        public virtual Message IdMessageNavigation { get; set; }
        public virtual User IdUserNavigation { get; set; }
    }
}
