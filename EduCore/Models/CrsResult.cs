namespace MVCFinalProject.Models
{
    public class CrsResult
    {
        public int Id { get; set; }
        public int Degree { get; set; }

        public int traineeId { get; set; }
        public int crsId { get; set; }

        public bool IsDeleted { get; set; }

        public Trainee trainee { get; set; }
        public Course course { get; set; }
    }
}
