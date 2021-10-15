using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace WebAPI.Model
{
    public class UserModel
    {
        [JsonProperty("User")]
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
    }
}
