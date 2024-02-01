using System;
using tarefasAPI.Enums;
using tarefasAPI.Models;

public class TarefaModel : Entity
{
    public string? Nome { get; set; }
    public string? Descricao { get; set; }
    public StatusTarefa Status { get; set; }
}
