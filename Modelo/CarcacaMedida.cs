using System;
using System.Collections.Generic;
using System.Text;

namespace Modelo
{
    public class CarcacaMedida : EntidadeDominio
    {
        private int _Posicao;
        private string _Medicao;
        private string _Tolerancia;
        private int _Id_Carcaca;
        private DateTime _Dt_Cadastro;
        private Usuario _UsuarioCriador;
        private string _Descricao;

        public string Tolerancia { get => _Tolerancia; set => _Tolerancia = value; }
        public string Medicao { get => _Medicao; set => _Medicao = value; }
        public int Posicao { get => _Posicao; set => _Posicao = value; }
        public int Id_Carcaca { get => _Id_Carcaca; set => _Id_Carcaca = value; }
        public DateTime Dt_Cadastro { get => _Dt_Cadastro; set => _Dt_Cadastro = value; }
        public Usuario UsuarioCriador { get => _UsuarioCriador; set => _UsuarioCriador = value; }
        public string Descricao { get => _Descricao; set => _Descricao = value; }
    }
}
