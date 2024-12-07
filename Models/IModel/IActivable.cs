namespace GestionDeAulas.Models.IModel
{
    public interface IActivable
    {
        public bool? IsActive { get; set; }
        public string? Id { get; set; }
    }
}
