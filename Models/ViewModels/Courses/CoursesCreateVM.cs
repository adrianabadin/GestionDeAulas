namespace GestionDeAulas.Models.ViewModels.Courses
{
    public class CoursesCreateVM: Course
    {
        public virtual ICollection<Institutions>? Institutions {  get; set; }
        public override Institutions? Institution { get; set; }
    }
}
