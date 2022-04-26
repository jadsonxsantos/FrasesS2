using System;
using System.Collections.Generic;
using System.Text;

namespace FrasesS2.Models
{
    public class UserMural
    {
        public Guid UserMuralId { get; set; }
        public bool Disponivel { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public string Link { get; set; }
        public DateTime Data { get; set; }
       
    }
}
