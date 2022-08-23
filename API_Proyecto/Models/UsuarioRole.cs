using System;
using System.Collections.Generic;

namespace API_Proyecto.Models
{
    public partial class UsuarioRole
    {
        public int UsuarioRoleId { get; set; }
        public int UsuarioId { get; set; }
        public int RoleId { get; set; }

        public virtual Role Role { get; set; } = null!;
        public virtual Usuario Usuario { get; set; } = null!;
    }
}
