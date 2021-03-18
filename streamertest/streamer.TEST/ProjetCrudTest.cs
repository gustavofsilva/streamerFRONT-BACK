using Microsoft.Extensions.DependencyInjection;
using SS_API.Data;
using SS_API.Model;
using Streamer.Test;
using streamertest.Services;
using Xunit;
using static Streamer.Test.BaseTest;

namespace streamer.TEST
{
    public class ProjetCrudTest : BaseTest, IClassFixture<DbTest>
    {
        private ServiceProvider _serviceProvide;

        public ProjetCrudTest(DbTest dbTest)
        {
            _serviceProvide = dbTest.serviceProvider;
        }

        [Fact(DisplayName = "CRUD de Project")]
        [Trait("CRUD", "Project")]
        public void E_Possivel_Realizar_CRUD_Project () 
        {
            using (var context = _serviceProvide.GetService<StreamerContext>()) 
            {
                ProjectServices _projectService = new ProjectServices(context);
                Project _entity = new Project()
                {
                    Id = 1,
                    Name = "luiz",
                    Image = "image.jpg",
                    Why = "Why",
                    What = "What",
                    WhatWillWeDo = "whatWill",      
                    CourseId = 1,              
                    Course = new Course() 
                    {
                        Id = 1,
                        Name = "Português"                        
                    },
                };

                var _registroCriado = _projectService.AddProjectCourse(_entity);
                
                //NULL tests
                Assert.NotNull(_registroCriado);
                Assert.NotNull(_registroCriado.Course);

                //Equal project
                Assert.Equal("luiz", _registroCriado.Name);
                Assert.Equal("image.jpg", _registroCriado.Image);
                Assert.Equal("Why", _registroCriado.Why);
                Assert.Equal("What",_registroCriado.What);
                Assert.Equal("whatWill", _registroCriado.WhatWillWeDo);

                //Equal Course
                Assert.Equal("Português", _registroCriado.Course.Name);   

            }

        }
        
    }
}