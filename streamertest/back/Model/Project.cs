using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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

        public Course Course { get; set; }

        [ForeignKey("Course")]        
        public int CourseId { get; set; }

    }
    
}