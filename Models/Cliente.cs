using System.ComponentModel.DataAnnotations;
using Teste_MVC_FranciscoBispo.Enums;
using Teste_MVC_FranciscoBispo.Models.CustomAttributes;

namespace Teste_MVC_FranciscoBispo.Models;

public class Cliente
{
    public int Id { get; set; }
    public required string Nome { get; set; }
    public TipoClienteEnum Tipo { get; set; }
    [Documento]
    public required string Documento { get; set; }
    public DateTime DataCadastro { get; set; }
    public required string Telefone { get; set; }
    public bool IsDeleted { get; set; }
}
