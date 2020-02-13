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

            //string pNumber = "P0007";
            //string pName = "Project with int stage";
            //int pStage = 2;
            //string pPI = "Mr Inty";
            //DateTime? pStartDate = Convert.ToDateTime("24/02/2020");
            //DateTime? pEndDate = null;

            //call member method to display projects
            Console.WriteLine(Projects.getProjectsToString());

            Console.WriteLine("");

            ////add a new project
            //Projects.insertProject(pNumber, pName, pStage, pPI, pStartDate, pEndDate);

            ////update existing project - first perform logical delete then insert new record
            //Projects.deleteProject(pNumber);
            //Projects.insertProject(pNumber, pName, pStage, pPI, pStartDate, pEndDate);

            ////refresh the DataSet
            //Projects.ds_Project = Projects.getProjectsDataSet();
            ////print to console
            //Console.WriteLine(Projects.getProjectsToString());
        }
    }                                                        
}
