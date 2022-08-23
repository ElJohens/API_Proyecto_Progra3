using System;
using System.Collections.Generic;

namespace API_Proyecto.Models
{
    public partial class Password
    {
        public int PasswordId { get; set; }
        public string? PasswordText { get; set; }
        public int UserdId { get; set; }

        public virtual Usuario Userd { get; set; } = null!;
    }
}
