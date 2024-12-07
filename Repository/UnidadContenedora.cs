using GestionDeAulas.Models;
using GestionDeAulas.Repository.IRepository;

namespace GestionDeAulas.Repository
{
    public class UnidadContenedora :IUnidadContenedora
    {
        public AppDbContext _context;
        public ClassesRepository _classes { get; set; }
        public UserRepository _users { get; set; }
        public RolesRepository _roles { get; set; }
        public IInstitutionsRepository _institutions { get; set; }
        public ICoursesRepository _courses { get; set; }
        public IClassRoomRepository _classRoom {  get; set; }
        public IReserveRepository _reserve { get; set; }
        public UnidadContenedora(AppDbContext context)
        {
            _context= context;
            _classes = new ClassesRepository(context);
            _users = new UserRepository(context);
            _roles = new RolesRepository(context);
            _institutions= new InstitutionsRepository(context);
            _courses=new CoursesRepository(context);
        _classRoom= new ClassRoomRepository(context);
        _reserve =new ReserveRepository(context);
        }

        public void Dispose()
        {
            _context.Dispose();
        }
        public async Task Save() {
            await _context.SaveChangesAsync();
        }
    }
}
