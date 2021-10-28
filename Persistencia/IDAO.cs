using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Modelo;

namespace Persistencia
{
    public interface IDAO
    {

       Boolean Inserir(EntidadeDominio entidade);
       Boolean Alterar(EntidadeDominio entidade);
       List<EntidadeDominio> ConsultarTodos(EntidadeDominio entidade);
       EntidadeDominio ConsultaUm(EntidadeDominio entidade);

    }
}
