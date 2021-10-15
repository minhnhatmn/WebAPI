using System;
using System.Collections.Generic;

#nullable disable

namespace WebAPI.EF
{
    public partial class FriendlistDetail
    {
        public int IdFriendlist { get; set; }
        public int IdUser { get; set; }
        public DateTime? TimeAdd { get; set; }

        public virtual Friendlist IdFriendlistNavigation { get; set; }
        public virtual User IdUserNavigation { get; set; }
    }
}
