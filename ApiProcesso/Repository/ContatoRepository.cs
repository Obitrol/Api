using ApiProcesso.Data;
using ApiProcesso.Model;
using ApiProcesso.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace ApiProcesso.Repository
{
    public class ContatoRepository : IContatoRepository
    {
        private readonly ContatosContext _cone;
        public ContatoRepository(ContatosContext contatosContext)
        {
            _cone = contatosContext;
        }
        public async Task<ContatoModel> Adicionar(ContatoModel contato)
        {
            await _cone.Contatos.AddAsync(contato);
            await _cone.SaveChangesAsync();
            return contato;
        }

        public async Task<ContatoModel> Atualizar(ContatoModel contato)
        {
            ContatoModel contatoModel = await _cone.Contatos.FirstOrDefaultAsync(x => x.id == contato.id);
            if (contatoModel == null)
            {
                throw new Exception("Não foi encontrado nenhum registro com esse ID");
            }
            contatoModel.nome = contato.nome;
            contatoModel.contato = contato.contato;
            _cone.Contatos.Update(contatoModel);
            await _cone.SaveChangesAsync();
            return contatoModel;
        }

        public async Task<List<ContatoModel>> BuscarTodos()
        {
            return await _cone.Contatos.ToListAsync();
        }

        public async Task<bool> Remover(int id)
        {
            ContatoModel contatoModel = await _cone.Contatos.FirstOrDefaultAsync(x => x.id == id);
            if (contatoModel == null)
            {
                throw new Exception("Não foi encontrado nenhum registro com esse ID");
            }
            _cone.Contatos.Remove(contatoModel);
            await _cone.SaveChangesAsync();
            return true;
        }
    }
}
