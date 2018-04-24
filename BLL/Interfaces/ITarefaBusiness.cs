using Model;
using System;
using System.Collections.Generic;

namespace BLL.Interfaces
{
    public interface ITarefaBusiness
    {
        void Adicionar(Tarefa obj);

        void Atualizar(Tarefa obj);

        void Excluir(Tarefa obj);

        Tarefa ObterPorId(int id);

        IEnumerable<Tarefa> ObterLista();

        IEnumerable<Tarefa> ObterLista(Func<Tarefa, bool> where);

        IEnumerable<Tarefa> ObterLista(TarefaDto filtro);
    }
}