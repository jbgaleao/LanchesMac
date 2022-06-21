using LanchesMac.Context;

namespace LanchesMac.Models
{
    public class CarrinhoCompra
    {
        private readonly AppDbContext _context;

        public CarrinhoCompra(AppDbContext context)
        {
            _context = context;
        }

        public string CarringoCompraId { get; set; }

        public List<CarrinhoCompraItem> CarrinhoCompraItems { get; set; }

        public static CarrinhoCompra GetCarrinho(IServiceProvider services)
        {
            //define uma sessao
            ISession session =
                services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;

            //obtem um servico do tipo do nosso contexto
            var context = services.GetService<AppDbContext>();

            // obtem ou gera o Id do carrinho 
            string carrinhoId = session.GetString("CarrinhoId") ??
                Guid.NewGuid().ToString();

            // atribui o id do carrinho na Sessao
            session.SetString("CarrinhoId", carrinhoId);

            //retorna o carrinho com o contexto e o Id atribuido ou obtido
            return new CarrinhoCompra(context)
            {
                CarringoCompraId = carrinhoId,
            };
        }

        public void AdicionarCompraItem(Lanche lanche)
        {
            var CarrinhoCompraItem =
                _context.CarrinhoCompraItens.SingleOrDefault(
                    s => s.Lanche.LancheId == lanche.LancheId &&
                    s.CarrinhoCompraId == CarringoCompraId);

            if (CarrinhoCompraItem==null)
            {
                CarrinhoCompraItem = new CarrinhoCompraItem()
                {
                    CarrinhoCompraId = CarringoCompraId,
                    Lanche = lanche,
                    Quantidade = 1
                };
                _context.CarrinhoCompraItens.Add(CarrinhoCompraItem);   
            }
            else
            {
                CarrinhoCompraItem.Quantidade = 1;
            }
            _context.SaveChanges();
        }
    }
}

