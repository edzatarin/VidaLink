using BLL.Interfaces;
using DAL;
using DAL.Interfaces;
using Model;
using System;
using System.Collections.Generic;

namespace BLL
{
    public class TarefaBusiness : ITarefaBusiness
    {
        private readonly ITarefaRepository _tarefaRepository;

        public TarefaBusiness()
        {
            // instância pode ser substituída por DI
            _tarefaRepository = new TarefaRepository();
        }

        public void Adicionar(Tarefa obj) => _tarefaRepository.Adicionar(obj);

        public void Atualizar(Tarefa obj) => _tarefaRepository.Atualizar(obj);

        public void Excluir(Tarefa obj) => _tarefaRepository.Excluir(obj);

        public IEnumerable<Tarefa> ObterLista() => _tarefaRepository.ObterLista();

        public Tarefa ObterPorId(int id) => _tarefaRepository.ObterPorId(id);

        public IEnumerable<Tarefa> ObterLista(Func<Tarefa, bool> where) => _tarefaRepository.ObterLista(where);

        public IEnumerable<Tarefa> ObterLista(TarefaDto filtro) => _tarefaRepository.ObterLista(filtro);
    }
}