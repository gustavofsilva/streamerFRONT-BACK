using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using SS_API.Model;
using streamertest.Services;

namespace SS_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        private readonly ProjectServices _contexto;

        public ProjectController(ProjectServices contexto)
        {
            _contexto = contexto;
        }

        [HttpGet]
        public IEnumerable<Project> List (){
            return _contexto.Projects;
        }

        [HttpGet("CourseId")]
        public IEnumerable<Project> GetByCourse (int CourseId) {
            return _contexto.Projects.Where(p => p.CourseId == CourseId);
        }

        [HttpGet("{Id}")]
        public Project GetById (int Id) {
            return _contexto.Projects.FirstOrDefault(p => p.Id == Id);
        }        

        [HttpPut("{project}")] 
        public bool Update (Project project) {
            Project _project;
            try {
                _project = GetById(project.Id);
                if (_project == null) return false;
                _project.Name = project.Name;
                _project.Image = project.Image;
                _project.Why = project.Why;
                _project.What = project.What;
                _project.WhatWillWeDo = project.WhatWillWeDo;
                _project.CourseId = project.CourseId;
                _contexto.Update(_project);
                return true;
            } catch {
                return false;
            }
        }

        [HttpDelete("{Id}")]
        public bool Delete (int Id) {
            var _project = GetById(Id);
            if (_project == null) return false;

            try {
                _contexto.RemoveProjectById(Id);
                return true;
            } catch {
                return false;
            }
        }

        [HttpPost("{project}")]
        public int Create (Project project) {
            if (project == null) return -1;

            _contexto.AddProject(project);
            return project.Id;
        }
    }
}