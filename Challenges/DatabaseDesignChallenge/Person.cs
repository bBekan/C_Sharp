using System.Collections.Generic;

namespace DatabaseDesignChallenge
{
    public class Person
    {
        public string name { get; set; }
        public string surname { get; set; }
        public int personId { get; set; }
        public string address { get; set; }
        public List<Present> presents { get; set; }

        public Person()
        {
            presents = new List<Present>();
        }
    }
}