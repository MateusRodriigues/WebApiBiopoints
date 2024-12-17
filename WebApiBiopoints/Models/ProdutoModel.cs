namespace WebApiBiopoints.Models
{
    public class ProdutoModel
    {
        public int Id { get; set; } // Correspondente a `pr_id`
        public string Nome { get; set; } // Correspondente a `pr_nome`
        public bool Status { get; set; } // Correspondente a `pr_status` (1 - ativado, 0 - desativado)
        public string Observacao { get; set; } // Correspondente a `pr_observacao`
        //public decimal PrecoBronze { get; set; } // Correspondente a `pr_bronze`
        //public decimal PrecoPrata { get; set; } // Correspondente a `pr_prata`
        //public decimal PrecoOuro { get; set; } // Correspondente a `pr_ouro`
        public int Unidade { get; set; } // Correspondente a `pr_unidade`
        public int? CodigoProduto { get; set; } // Correspondente a `pr_codigo_produto`
        public string Descricao { get; set; } // Correspondente a `pr_descricao`
        public string Imagem { get; set; } // Correspondente a `pr_imagem`
        //public int? CadastradoPor { get; set; } // Correspondente a `pr_cadastrado_por`
        //public int? PontosBronze { get; set; } // Correspondente a `pr_pontos_bronze`
        //public int? PontosPrata { get; set; } // Correspondente a `pr_pontos_prata`
        //public int? PontosOuro { get; set; } // Correspondente a `pr_pontos_ouro`
    }

}
