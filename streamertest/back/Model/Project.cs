using System;
using System.ComponentModel.DataAnnotations;

namespace SS_API.Model
{
    public class Project
    {
        [Key]
        public int Id { get; set; }

        [Required][StringLength(150)]
        public String Name { get; set; }

        [StringLength(250)]
        public String Image { get; set; }

        [StringLength(150)]
        public String Why { get; set; }

        [StringLength(150)]
        public String What { get; set; }

        [StringLength(150)]
        public String WhatWillWeDo { get; set; }

        //SQLite não tem referência ENUM
        public enum ProjectStatus
        {
            Desenvolvimento = 0,
            Publicado = 1
            
        }

        [Required]
        public Course Course { get; set; }
        
        public int CourseId { get; set; }

    }
    
}