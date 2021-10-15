using System;
using System.Collections.Generic;

#nullable disable

namespace WebAPI.EF
{
    public partial class GroupDetail
    {
        public int IdGroup { get; set; }
        public int IdUser { get; set; }
        public int? TypeAdmin { get; set; }
        public int? IsNotification { get; set; }

        public virtual Group IdGroupNavigation { get; set; }
        public virtual User IdUserNavigation { get; set; }
    }
}
