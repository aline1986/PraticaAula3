using System;
using System.Collections.Generic;
using System.Text;

namespace PraticaAula3.Entities
{
    public class Produto
    {
        public Guid IdProduto { get; set; }
        public string Nome { get; set; }

        public decimal Preco { get; set; }

        public int Quantidade { get; set; }

        public DateTime DataCompra { get; set; }
    }
}
