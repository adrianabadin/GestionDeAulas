using GestionDeAulas.Models;
using GestionDeAulas.Repository.IRepository;

namespace GestionDeAulas.Repository
{
    public class ClassRoomRepository :Repository<ClassRoom>,IClassRoomRepository
    {
        public readonly AppDbContext _context;
        public ClassRoomRepository(AppDbContext context) :base(context)
        {
            _context = context;   
        }

        public async Task Update(ClassRoom entity)
        {
            var temporalEntity = await Db.FindAsync(entity.Id);
            if (temporalEntity == null) throw new Exception("No se encontro el Salon");
            temporalEntity.Description = entity.Description ?? temporalEntity.Description;
            temporalEntity.Seats = entity.Seats !=0 ? entity.Seats: temporalEntity.Seats ;
            temporalEntity.Name= entity.Name ?? temporalEntity.Name;
            temporalEntity.IsSpecial = entity.IsSpecial;
            await _context.SaveChangesAsync();

        }
    }
}
