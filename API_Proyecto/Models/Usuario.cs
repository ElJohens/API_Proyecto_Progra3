using System;
using System.Collections.Generic;

namespace API_Proyecto.Models
{
    public partial class Usuario
    {
        public Usuario()
        {
            Passwords = new HashSet<Password>();
            UsuarioRoles = new HashSet<UsuarioRole>();
        }

        public int UsuarioId { get; set; }
        public string UsuarioNombre { get; set; } = null!;
        public string UsuarioApellidos { get; set; } = null!;
        public string UsuarioIdentificacion { get; set; } = null!;
        public string UsuarioCorreo { get; set; } = null!;
        public string UsuarioTelefono { get; set; } = null!;
        public string UsuarioAlias { get; set; } = null!;

        public virtual ICollection<Password> Passwords { get; set; }
        public virtual ICollection<UsuarioRole> UsuarioRoles { get; set; }
    }
}
