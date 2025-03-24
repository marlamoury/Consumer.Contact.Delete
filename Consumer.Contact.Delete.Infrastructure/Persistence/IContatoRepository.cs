using Consumer.Delete.Contact.Domain.Entities;
using System.Threading.Tasks;

namespace Consumer.Delete.Contact.Infrastructure.Persistence
{
    public interface IContatoRepository
    {
        Task DeleteContatoAsync(int id);
    }
}
