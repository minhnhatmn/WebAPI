using System;
using System.Collections.Generic;

#nullable disable

namespace WebAPI.EF
{
    public partial class File
    {
        public int IdAttachment { get; set; }
        public int? IdMessage { get; set; }
        public string Url { get; set; }
        public int? TypeFile { get; set; }

        public virtual Message IdMessageNavigation { get; set; }
    }
}
