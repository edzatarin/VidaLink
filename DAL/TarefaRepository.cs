using DAL.Interfaces;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DAL
{
    public class TarefaRepository : ITarefaRepository
    {
        public void Adicionar(Tarefa obj) => RetornarListaTarefa().Add(obj);

        public void Atualizar(Tarefa obj)
        {
            var tarefa = ObterPorId(obj.Id);
            tarefa = obj;
        }

        public void Excluir(Tarefa obj) => RetornarListaTarefa().Remove(obj);

        public IEnumerable<Tarefa> ObterLista() => RetornarListaTarefa();

        public IEnumerable<Tarefa> ObterLista(Func<Tarefa, bool> where)
            => RetornarListaTarefa().Where(where);

        public IEnumerable<Tarefa> ObterLista(TarefaDto filtro)
        {
            bool expr(Tarefa p) =>
                !string.IsNullOrEmpty(filtro.Descricao) ? p.Descricao.Contains(filtro.Descricao) : true
                &&
                !string.IsNullOrEmpty(filtro.Titulo) ? p.Titulo.Contains(filtro.Titulo) : true;

            return RetornarListaTarefa().Where(expr);
        }          

        public Tarefa ObterPorId(int id) => RetornarListaTarefa().FirstOrDefault(f => f.Id == id);

        #region Métodos Privados

        private List<Tarefa> RetornarListaTarefa()
        {
            return new List<Tarefa>
            {
                new Tarefa
                {
                    Id = 1,
                    DataExecucao = DateTime.Now,
                    Descricao = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.",
                    Titulo = "Lorem Ipsum"
                },
                new Tarefa
                {
                    Id = 2,
                    DataExecucao = DateTime.Now.AddDays(-1),
                    Descricao = "Sed ut perspiciatis unde omnis iste natus error sit voluptatem accusantium doloremque laudantium.",
                    Titulo = "Finibus Bonorum et Malorum"
                },
                new Tarefa
                {
                    Id = 3,
                    DataExecucao = DateTime.Now.AddDays(1),
                    Descricao = "At vero eos et accusamus et iusto odio dignissimos ducimus qui blanditiis praesentium voluptatum.",
                    Titulo = "Et harum quidem rerum"
                }
            };
        }

        #endregion Métodos Privados
    }
}