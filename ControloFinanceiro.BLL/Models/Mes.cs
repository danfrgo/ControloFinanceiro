﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ControloFinanceiro.BLL.Models
{
    public class Mes
    {
        public int MesId { get; set; }
        public string Nome { get; set; }

        // relacionamentos
        public virtual ICollection<Despesa> Despesas { get; set; }
        public virtual ICollection<Ganho> Ganhos { get; set; }
    }
}
