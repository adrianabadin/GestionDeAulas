namespace GestionDeAulas.Repository.IRepository
{
    public interface IUnidadContenedora :IDisposable

    {
        public Task Save();
    }
}
