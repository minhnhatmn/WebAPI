using System;
using System.Collections.Generic;

#nullable disable

namespace WebAPI.EF
{
    public partial class User
    {
        public User()
        {
            FriendlistDetails = new HashSet<FriendlistDetail>();
            Friendlists = new HashSet<Friendlist>();
            GroupDetails = new HashSet<GroupDetail>();
            MessageSeens = new HashSet<MessageSeen>();
            Messages = new HashSet<Message>();
            UserDevices = new HashSet<UserDevice>();
        }

        public int IdUser { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public DateTime? TimeDelete { get; set; }
        public int? IsActive { get; set; }
        public string AvatarUrl { get; set; }
        public string Name { get; set; }
        public DateTime? Dob { get; set; }
        public string Email { get; set; }
        public string Phonenumber { get; set; }

        public virtual ICollection<FriendlistDetail> FriendlistDetails { get; set; }
        public virtual ICollection<Friendlist> Friendlists { get; set; }
        public virtual ICollection<GroupDetail> GroupDetails { get; set; }
        public virtual ICollection<MessageSeen> MessageSeens { get; set; }
        public virtual ICollection<Message> Messages { get; set; }
        public virtual ICollection<UserDevice> UserDevices { get; set; }
    }
}
