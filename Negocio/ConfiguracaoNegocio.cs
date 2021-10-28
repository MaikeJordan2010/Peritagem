using Modelo;
using Persistencia;
using System;
using System.Collections.Generic;
using System.Text;

namespace Negocio
{
    public class ConfiguracaoNegocio
    {
        public List<Configuracao> ListarConfiguracao()
        {
            ConfiguracaoDAO confDao = new ConfiguracaoDAO();
            return confDao.ListarConfiguracao();
        }

        public Configuracao ConsultarUM(int ID_Configuracao)
        {
            ConfiguracaoDAO confDao = new ConfiguracaoDAO();
            return confDao.ConsultarUm(ID_Configuracao);
        }

        public bool InserirConfiguracao(Configuracao conf)
        {
            ConfiguracaoDAO confDao = new ConfiguracaoDAO();
            return confDao.InserirConfiguracao(conf);
        }

        public bool AlterarConfiguracao(Configuracao conf)
        {
            ConfiguracaoDAO confDao = new ConfiguracaoDAO();
            return confDao.AlterarConfiguracao(conf);
        }
        public bool ExcluirConfiguracao(Configuracao conf)
        {
            ConfiguracaoDAO confDao = new ConfiguracaoDAO();
            return confDao.ExcluirConfiguracao(conf);
        }
        public bool AlterarPadrao(Configuracao conf)
        {
            ConfiguracaoDAO confDao = new ConfiguracaoDAO();
            return confDao.AlterarPadrao(conf);
        }



    }
}
