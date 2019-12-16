namespace JsonMapping.Models
{
    public class Football : ISport
    {
        public string Name => "Football";
        public string PitchName { get; set; }
    }
}