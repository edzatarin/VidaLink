using BLL;
using BLL.Interfaces;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using VidaLink.Models;

namespace VidaLink.Controllers
{
    public class TarefaController : Controller
    {
        private readonly ITarefaBusiness _tarefaBusiness;

        public TarefaController()
        {
            // instância pode ser substituída por DI
            _tarefaBusiness = new TarefaBusiness();
        }

        public ActionResult Index()
        {
            return View(new TarefaViewModel());
        }

        [HttpPost]
        public ActionResult Pesquisar(TarefaViewModel model)
        {
            var dto = MapearTarefaViewModelDto(model);
            var tarefas = _tarefaBusiness.ObterLista(dto);

            // pode ser utilizado automapper
            var viewModel = MapearTarefaViewModel(tarefas);

            return PartialView("_Grid", viewModel);
        }

        [HttpPost]
        public ActionResult Salvar(TarefaViewModel model)
        {
            var tarefa = MapearTarefaViewModel(model);
            _tarefaBusiness.Adicionar(tarefa);

            return Json(new { mensagem = "Tarefa adicionada com sucesso." }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Excluir(int id)
        {
            var tarefa = _tarefaBusiness.ObterPorId(id);
            _tarefaBusiness.Excluir(tarefa);

            var tarefas = _tarefaBusiness.ObterLista(o => o.Id != id);
            var viewModel = MapearTarefaViewModel(tarefas);

            return PartialView("_Grid", viewModel);
        }

        #region Métodos Privados

        private Tarefa MapearTarefaViewModel(TarefaViewModel viewModel)
        {
            return new Tarefa
            {
                Id = viewModel.Id,
                DataExecucao = viewModel.DataExecucao.HasValue ? viewModel.DataExecucao.Value : DateTime.Now,
                Descricao = viewModel.Descricao,
                Titulo = viewModel.Titulo
            };
        }

        private IEnumerable<TarefaViewModel> MapearTarefaViewModel(IEnumerable<Tarefa> tarefas)
        {
            var listaViewModel = tarefas.Select(s => new TarefaViewModel
            {
                Id = s.Id,
                DataExecucao = s.DataExecucao,
                Descricao = s.Descricao,
                Titulo = s.Titulo
            });

            return listaViewModel;
        }

        private TarefaDto MapearTarefaViewModelDto(TarefaViewModel tarefa)
        {
            return new TarefaDto
            {
                Descricao = tarefa.Descricao,
                Titulo = tarefa.Titulo
            };
        }

        #endregion Métodos Privados
    }
}