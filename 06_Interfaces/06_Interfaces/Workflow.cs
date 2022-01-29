using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06_Interfaces
{
    internal class Workflow
    {
        public IList<IActivity> ActivityList { get; private set; } = new List<IActivity>();

        public void Add(params IActivity[] activity)
        {
            foreach(var action in activity)
            {
                ActivityList.Add(action);
            }
        }
        public void Remove(IActivity activity)
        {
            ActivityList.Remove(activity);
        }

    }
}
