using System;
using System.Collections.Generic;

#nullable disable

namespace WebAPI.EF
{
    public partial class Group
    {
        public Group()
        {
            GroupDetails = new HashSet<GroupDetail>();
            Messages = new HashSet<Message>();
        }

        public int IdGroup { get; set; }
        public DateTime? TimeCreate { get; set; }
        public DateTime? TimeDelete { get; set; }
        public int? IdLastmessage { get; set; }
        public int? TypeGroup { get; set; }
        public string NameGroup { get; set; }

        public virtual Message IdLastmessageNavigation { get; set; }
        public virtual ICollection<GroupDetail> GroupDetails { get; set; }
        public virtual ICollection<Message> Messages { get; set; }
    }
}
