using MVCFinalProject.Models;

namespace MVCFinalProject.ViewModels
{
    public class SearchDataViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Salary { get; set; }
        public string?  Address { get; set; }

        public string? department { get; set; }
        public string? course { get; set; }
    }
}
