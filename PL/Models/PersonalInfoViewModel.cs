namespace PL.Models
{
    public class PersonalInfoViewModel
    {
        public string Email { get; set; }
        public string PhoneNumber { get; set; }

        public PersonalInfoViewModel()
        {

        }

        public PersonalInfoViewModel(List<string> parameterList)
        {
            this.Email = parameterList[0];
            this.PhoneNumber = parameterList[1];
        }
    }
}