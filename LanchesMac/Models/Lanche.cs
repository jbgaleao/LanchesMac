namespace LanchesMac.Models
{
    public class Lanche
    {
        public int LancheId { get; set; }
        public string Name { get; set; }
        public string DescricaoCurta { get; set; } 
        public string DescricaoDetalhada { get; set; }
        public decimal Preco { get; set; }
        public string imagemUrl{ get; set; }
        public string ImagemThumbnail { get; set; }
        public bool IsLanchPreferido { get; set; }
        public bool EmEstoque { get; set; }

        public int CategoriaId { get; set; }
        public virtual Categoria Categoria { get; set; }
    }
}
