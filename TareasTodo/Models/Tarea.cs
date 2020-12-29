using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TareasTodo.Models
{
    public class Tarea
    {
        public int Id { get; set; }
        [StringLength(10,ErrorMessage ="menos de 10 lineas")]
        public String Descripcion { get; set; }

        public bool Completada { get; set; }
    }
}
