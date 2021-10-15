using System;
using System.Collections.Generic;

#nullable disable

namespace WebAPI.EF
{
    public partial class Message
    {
        public Message()
        {
            Files = new HashSet<File>();
            Groups = new HashSet<Group>();
            InverseIdMessagereplyNavigation = new HashSet<Message>();
            MessageSeens = new HashSet<MessageSeen>();
        }

        public int IdMessage { get; set; }
        public int? IdUsersent { get; set; }
        public string ContentText { get; set; }
        public int? IdMessagereply { get; set; }
        public DateTime? TimeDelete { get; set; }
        public DateTime? TimeSent { get; set; }
        public int? IdGroup { get; set; }
        public string TypeMessage { get; set; }
        public DateTime? TimeEdit { get; set; }

        public virtual Group IdGroupNavigation { get; set; }
        public virtual Message IdMessagereplyNavigation { get; set; }
        public virtual User IdUsersentNavigation { get; set; }
        public virtual ICollection<File> Files { get; set; }
        public virtual ICollection<Group> Groups { get; set; }
        public virtual ICollection<Message> InverseIdMessagereplyNavigation { get; set; }
        public virtual ICollection<MessageSeen> MessageSeens { get; set; }
    }
}
