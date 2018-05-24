using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FTHWebapp.Interfaces;
using FTHWebapp.Models;
using FTHWebapp.SqlContext;

namespace FTHWebapp.Repository
{
    public class ProjectRepo 
    {
        private readonly IProjectContext _projectcontext;
        
        public ProjectRepo(IProjectContext context)
        {
            _projectcontext = context;
        }

        public void AddProject(Project project)
        {
            _projectcontext.AddProject(project);

        }
        public void delete()
        {
            throw new NotImplementedException();
        }

        public void FilterProjects()
        {
            throw new NotImplementedException();
        }

        public List<Project> GetAllProjects()
        {
            return _projectcontext.GetAllProjects();
        }

        public List<Project> GetTypes()
        {
            return _projectcontext.GetTypes();
        }
        public Project GetDetails(int projectid)
        {
            return _projectcontext.GetDetails(projectid);
        }
    }
}
