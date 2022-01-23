using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    internal class Post
    {
        private string Title;
        private string Description;
        private DateTime TimeCreated;
        private int NumberOfLikes;


        public Post(string title, string description)
        {

                if (String.IsNullOrWhiteSpace(title) || String.IsNullOrWhiteSpace(description)) throw  new ArgumentNullException();
                this.Title = title;
                this.Description = description;
                TimeCreated = DateTime.Now;
                NumberOfLikes = 0;
            
        }

        public void Like()
        {
            NumberOfLikes++;
        }

        public void Dislike()
        {
            NumberOfLikes--;
        }


        public void DisplayPost()
        {
            Console.WriteLine("Title: {0}\nDescription:{1}\nLikes: {2}\nCreated: {3}\n",Title, Description, NumberOfLikes, TimeCreated);
        }
    } 
}
