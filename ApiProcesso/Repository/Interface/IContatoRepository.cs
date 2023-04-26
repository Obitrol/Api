using ApiProcesso.Model;

namespace ApiProcesso.Repository.Interface
{
    public interface IContatoRepository
    {
        Task<List<ContatoModel>> BuscarTodos();
        Task<ContatoModel> Adicionar(ContatoModel contato);
        Task<bool> Remover(int id);
        Task<ContatoModel> Atualizar (ContatoModel contato);
    }
}
