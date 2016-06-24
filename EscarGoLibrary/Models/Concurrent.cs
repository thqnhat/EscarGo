﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;

namespace EscarGoLibrary.Models
{
    [DebuggerDisplay("{Nom}")]
    public class Concurrent
    {
        public Concurrent()
        {
            Courses = new List<Course>();
        }
        public string Nom { get; set; }
        [Key]
        public int ConcurrentId { get; set; }
        public int Victoires { get; set; }
        public int Defaites { get; set; }
        public Entraineur Entraineur { get; set; }
        public int EntraineurId { get; set; }
        [NotMapped]
        public double SC { get; set; }

        public ICollection<Course> Courses { get; set; }
    }
}
