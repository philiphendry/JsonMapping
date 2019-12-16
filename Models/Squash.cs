namespace JsonMapping.Models
{
    public class Squash : ISport
    {
        public string Name => "Squash";
        public string CourtName { get; set; }
    }
}