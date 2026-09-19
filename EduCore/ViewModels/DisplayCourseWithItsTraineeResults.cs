namespace MVCFinalProject.ViewModels
{
    public class DisplayCourseWithItsTraineeResults
    {
        public string CourseTitle { get; set; }

        public List<TraineeDataToDisplayInCourseResultViewModel> TraineeData { get; set; }
    }
}
