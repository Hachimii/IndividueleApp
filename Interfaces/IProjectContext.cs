using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FTHWebapp.SqlContext;
using FTHWebapp.Models;
using FTHWebapp.Repository;


namespace FTHWebapp.Interfaces
{
    public interface IProjectContext
    {
        List<Project> GetAllProjects();

        Project GetDetails(int projectid);

        List<Project> GetTypes();

        void AddProject(Project P);

        void FilterProjects();

        void delete();
    }
}
