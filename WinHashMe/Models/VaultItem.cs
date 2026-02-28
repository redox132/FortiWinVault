using System;
using System.Collections.Generic;
using System.Text;

namespace WinHashMe.Models
{
    public class VaultItem
    {
        public string? Website { get; set; }
        public string? Username { get; set; }
        public string? Password { get; set; } // Plain text for now
    }
}
