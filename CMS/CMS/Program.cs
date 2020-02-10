using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS
{
    class Program
    {
        static void Main(string[] args)
        {
            //instantiate new Project type object that contains details of all projects
            var Projects = new Project();
            //call member method to display projects
            Console.WriteLine(Projects.getProjectsToString());

            Console.WriteLine("");

            ////add a new project
            //Projects.insertProject("P0005", "An even newer project", "Setup", "Joe Pineapples");
            ////refresh the DataSet
            //Projects.ds_Project = Projects.getProjectsDataSet();
            ////print to console
            //Console.WriteLine(Projects.getProjects());

            ////update existing project - first perform logical delete then insert new record
            //Projects.deleteProject("P0004");
            //Projects.insertProject("P0004", "A newer project", "Closed", "Sticky Bob");
            
            //refresh the DataSet
            Projects.ds_Project = Projects.getProjectsDataSet();
            //print to console
            Console.WriteLine(Projects.getProjectsToString());
        }
    }                                                        
}
