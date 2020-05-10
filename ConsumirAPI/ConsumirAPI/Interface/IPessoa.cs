using ConsumirAPI.DTO;
using System.Threading.Tasks;

namespace ConsumirAPI.Interface
{
    public interface IPessoaService
    {
       Task<string> GetURI();
       Task<string> PostURI(PessoaDTO obj);
    }
}
