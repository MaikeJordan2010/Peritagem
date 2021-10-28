using Persistencia;
using System;
using System.Collections.Generic;
using System.Text;
using Modelo;

namespace Negocio
{
    public class ItemDiversoNegocio
    {
        public bool InserirItem(ItemDiverso item)
        {
            ItemDiversoDAO itemDao = new ItemDiversoDAO();

            item.Borracha = item.Borracha == null ? "" : item.Borracha;
            item.Codigo = item.Codigo == null ? "" : item.Codigo;
            item.Descricao = item.Descricao == null ? "" : item.Descricao;
            item.Dimensao = item.Dimensao == null ? "" : item.Dimensao;
            item.Fabricante =  item.Fabricante == null ? "" : item.Fabricante;
            item.Labio = item.Labio == null ? "" : item.Labio;
            item.LocalAplicado =  item.LocalAplicado == null ? "" : item.LocalAplicado;
            item.Marca = item.Marca == null ? "" : item.Marca;
            item.Modelo = item.Modelo == null ? "" : item.Modelo;
            item.Nome = item.Nome == null ? "" : item.Nome;
            item.Observacao = item.Observacao == null ? "" : item.Observacao;
            item.Passo = item.Passo == null ? "" : item.Passo;
            item.Produto = item.Produto == null ? "" : item.Produto;
            item.Rosca = item.Rosca == null ? "" : item.Rosca;

            return itemDao.Inserir(item);
        }

        public bool ExcluirItem(ItemDiverso item)
        {
            ItemDiversoDAO itemDao = new ItemDiversoDAO();

            return itemDao.ExcluirItemDiverso(item);
        }

        public bool AlterarItem(ItemDiverso item)
        {
            ItemDiversoDAO itemDao = new ItemDiversoDAO();

            item.Borracha = item.Borracha == null ? "" : item.Borracha;
            item.Codigo = item.Codigo == null ? "" : item.Codigo;
            item.Descricao = item.Descricao == null ? "" : item.Descricao;
            item.Dimensao = item.Dimensao == null ? "" : item.Dimensao;
            item.Fabricante = item.Fabricante == null ? "" : item.Fabricante;
            item.Labio = item.Labio == null ? "" : item.Labio;
            item.LocalAplicado = item.LocalAplicado == null ? "" : item.LocalAplicado;
            item.Marca = item.Marca == null ? "" : item.Marca;
            item.Modelo = item.Modelo == null ? "" : item.Modelo;
            item.Nome = item.Nome == null ? "" : item.Nome;
            item.Observacao = item.Observacao == null ? "" : item.Observacao;
            item.Passo = item.Passo == null ? "" : item.Passo;
            item.Produto = item.Produto == null ? "" : item.Produto;
            item.Rosca = item.Rosca == null ? "" : item.Rosca;

            return itemDao.Alterar(item);
        }

        public List<ItemDiverso> ConsultarTodos(ItemDiverso item)
        {
            ItemDiversoDAO itemDao = new ItemDiversoDAO();
            return itemDao.ConsultaTodos(item);
        }

        public ItemDiverso ConsultarUm(int ID_Item)
        {
            ItemDiversoDAO itemDao = new ItemDiversoDAO();
            return itemDao.ConsultaUm(ID_Item);
        }


        public bool AlterarCapa(int ID_ItemDiverso, string Capa)
        {
            ItemDiversoDAO itemDao = new ItemDiversoDAO();
            return itemDao.AlterarCapa(ID_ItemDiverso, Capa);
        }
    }
}
