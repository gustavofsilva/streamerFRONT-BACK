using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using SS_API.Data;
using SS_API.Model;

namespace streamertest.Services
{
    public class ProjectServices
    {
        private readonly StreamerContext _context;

        public ProjectServices(StreamerContext contexto)
        {
            _context = contexto;
        }

        public Project AddProject (Project project){
            project.Course = null;
            _context.Projects.Add(project);
            _context.SaveChanges();      
            return project;     
        }

        public Project AddProjectCourse (Project project){
            // project.Course = null;
            _context.Projects.Add(project);
            _context.SaveChanges();      
            return project;     
        }

        public IEnumerable<Project> Projects => _context.Projects.Include("Course");

        public void RemoveProject (Project project){
            _context.Projects.Remove(project);
            _context.SaveChanges();
        }

        public void Update (Project projectNew){
            // projectNew.Course = null;
            _context.Projects.Update(projectNew);
            _context.SaveChanges();
        }

        public void RemoveProjectById(int id)
        {
            Project project = _context.Projects.FirstOrDefault(p => p.Id == id);
            _context.Remove(project);
            _context.SaveChanges();
        }
    }
}