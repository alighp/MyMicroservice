namespace SampleApplication.Core.ApplicationService
{
    public partial class PersonAppService
    {
        public class AddNumberToPersonDto 
        {
            public int PersonId { get; set; }
            public string Number { get; set; }
        }
    }
}