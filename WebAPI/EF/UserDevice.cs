using System;
using System.Collections.Generic;

#nullable disable

namespace WebAPI.EF
{
    public partial class UserDevice
    {
        public int IdUserDevice { get; set; }
        public string DeviceName { get; set; }
        public int? IdUser { get; set; }
        public string DeviceToken { get; set; }
        public string LoginToken { get; set; }
        public DateTime? DeviceTimeCreate { get; set; }
        public DateTime? DeviceTimeExpried { get; set; }
        public DateTime? LoginTimeCreate { get; set; }
        public DateTime? LoginTimeExpried { get; set; }

        public virtual User IdUserNavigation { get; set; }
    }
}
