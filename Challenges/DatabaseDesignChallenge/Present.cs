namespace DatabaseDesignChallenge
{
    public class Present
    {
        public int presentId { get; set; }
        public string name { get; set; }
        public Person recipient { get; set; }
        public double cost { get; set; }
    }
}