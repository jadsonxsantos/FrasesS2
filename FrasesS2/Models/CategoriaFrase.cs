using System;
using System.Collections.Generic;
using System.Text;

namespace FrasesS2.Models
{
    public class CategoriaFrase
    {
        public string Categoria { get; set; }
        public string ImageCateg { get; set; }
        public string TituloCateg { get; set; }
        public List<FraseItem> Frases { get; set; }
    }
}
