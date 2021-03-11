using System.Collections.Generic;
using System.Linq;
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

        public void AddProject (Project project){
            _context.Projects.Add(project); 
            _context.SaveChanges();           
        }
        public IEnumerable<Project> Projects => _context.Projects;

        public void RemoveProject (Project project){
            _context.Projects.Remove(project);
            _context.SaveChanges();
        }

        public void Update (Project projectNew){
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