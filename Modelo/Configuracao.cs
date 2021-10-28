using System;
using System.Collections.Generic;
using System.Text;

namespace Modelo
{
    public class Configuracao : EntidadeDominio
    {
        private string _Nome;
        private string _Dominio;
        private string _Porta;
        private string _Descricao;
        private string _Protocolo;
        private bool _Padrao;

        public string Nome { get => _Nome; set => _Nome = value; }
        public string Dominio { get => _Dominio; set => _Dominio = value; }
        public string Porta { get => _Porta; set => _Porta = value; }
        public string Descricao { get => _Descricao; set => _Descricao = value; }
        public string Protocolo { get => _Protocolo; set => _Protocolo = value; }
        public bool Padrao { get => _Padrao; set => _Padrao = value; }
    }
}
