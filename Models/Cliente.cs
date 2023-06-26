using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace registroCliente.Models
{
    public class Cliente
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Dirección { get; set; }
        public string Telefono { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string Estado { get; set; }
    }
}
