using System;
using System.Collections.Generic;

#nullable disable

namespace WebAPI.EF
{
    public partial class Friendlist
    {
        public Friendlist()
        {
            FriendlistDetails = new HashSet<FriendlistDetail>();
        }

        public int IdFriendlist { get; set; }
        public int? IdUser { get; set; }

        public virtual User IdUserNavigation { get; set; }
        public virtual ICollection<FriendlistDetail> FriendlistDetails { get; set; }
    }
}
