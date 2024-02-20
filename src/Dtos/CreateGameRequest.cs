namespace GamesCatalogApi.Dtos
{
    // A criação de dtos é importante para que você consiga controlar exatamente o que entra na sua api
    // Por exemplo, no create vc está recebendo um game e está recebendo o id do game. Na prática isso não acontece, visto que o id será gerado pela sua app ou
    //  no banco de dados
    public class CreateGameRequest
    {
        public string Title { get; set; }
        public string Genre { get; set; }
        public string Developer { get; set; }
        public string Publisher { get; set; }
    }
}
