using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06_Interfaces
{
    internal class WorkflowEngine
    {

        public void Run(Workflow workflow)
        {
            foreach(var activity in workflow.ActivityList)
            {
                activity.Execute();
            }
            
        }
    }
}
