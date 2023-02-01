namespace PL.Models
{
    public class BodyParametersViewModel
    {
        public int Weight { get; set; }
        public int Height { get; set; }
        public int Breast { get; set; }
        public int Waist { get; set; }
        public int Hips { get; set; }

        public BodyParametersViewModel() 
        {

        }

        public BodyParametersViewModel(List<int> parameterList)
        {
            this.Weight = parameterList[0];
            this.Height = parameterList[1];
            this.Breast = parameterList[2];
            this.Waist = parameterList[3];
            this.Hips = parameterList[4];
        }
    }
}