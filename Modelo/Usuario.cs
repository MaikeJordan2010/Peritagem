using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Modelo
{
    public class Usuario
    {
        private string _Token;
        private int _Id;
        private string _Email;
        private string _Password;
        private string _Nome;
        private string _Foto;
        private string _Departamento;

        public string Nome { get => _Nome; set => _Nome = value; }
        public string Password { get => _Password; set => _Password = value; }
        public string Email { get => _Email; set => _Email = value; }
        public int Id { get => _Id; set => _Id = value; }
        public string Token { get => _Token; set => _Token = value; }
        public string Foto { get => _Foto; set => _Foto = value; }
        public string Departamento { get => _Departamento; set => _Departamento = value; }
    }
}
