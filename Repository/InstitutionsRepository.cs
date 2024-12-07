using GestionDeAulas.Models;
using GestionDeAulas.Repository.IRepository;

namespace GestionDeAulas.Repository
{
    public class InstitutionsRepository : Repository<Institutions>, IInstitutionsRepository
    {
        public InstitutionsRepository(AppDbContext context):base(context)
        {
            
        }
        public async Task<Institutions> Update(Institutions entity)
        {
            var institution = await Db.FindAsync(entity.Id);
            if (institution == null) throw new Exception("Institution not found");
            institution.Description = entity.Description;
            institution.ContactName = entity.ContactName;
            institution.PhoneNumber = entity.PhoneNumber;
            institution.Email = entity.Email;
            institution.Name= entity.Name;
            institution.IsActive = entity.IsActive;
            await Context.SaveChangesAsync();
            return institution;

        }
    }
}
