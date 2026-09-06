namespace MVCFinalProject.ViewModels
{
    public class CourseDataToDisplayTraineeResultsViewModel
    {
        public string Name { get; set; }
        public int  Degree { get; set; }
        public string State { get; set; }
        
        // Note: I can make another property for color,
        // but i will decide it in the view using State
    }
}
