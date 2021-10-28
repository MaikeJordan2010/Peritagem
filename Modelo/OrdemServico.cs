using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Modelo
{
    public class OrdemServico
    {
        private Cliente _Cliente;
        private string _Contrato;
        private string _Num_ordemServico;
        private string _Produto;
        private int _Id;
        private string _descricao;

        public string Descricao { get => _descricao; set => _descricao = value; }
        public int Id { get => _Id; set => _Id = value; }
        public string Produto { get => _Produto; set => _Produto = value; }
        public string Num_ordemServico { get => _Num_ordemServico; set => _Num_ordemServico = value; }
        public string Contrato { get => _Contrato; set => _Contrato = value; }
        public Cliente Cliente { get => _Cliente; set => _Cliente = value; }
    }
}
