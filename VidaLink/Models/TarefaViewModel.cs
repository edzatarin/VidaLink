using System;

namespace VidaLink.Models
{
    [Serializable()]
    public class TarefaViewModel
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public DateTime? DataExecucao { get; set; }
    }
}