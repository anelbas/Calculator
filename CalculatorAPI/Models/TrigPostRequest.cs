namespace CalculatorAPI.Models
{
    public class TrigPostRequest
    {

        public List<Trig>? Tags { get; set; }

        public TrigPostRequest(List<Trig> trig)
        {
            Tags = trig;
        }

        public TrigPostRequest()
        {
        }
    }
}