using System;
using System.Collections.Generic;

namespace API_Proyecto.Models
{
    public partial class Role
    {
        public Role()
        {
            UsuarioRoles = new HashSet<UsuarioRole>();
        }

        public int RoleId { get; set; }
        public string RoleNombre { get; set; } = null!;

        public virtual ICollection<UsuarioRole> UsuarioRoles { get; set; }
    }
}
