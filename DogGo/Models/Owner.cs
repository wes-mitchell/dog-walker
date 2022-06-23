﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DogGo.Models
{
    public class Owner
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Hmmm... You should really add a Name...")]
        [MaxLength(35)]
        public string Name { get; set; }
        [EmailAddress]
        [Required]
        public string Email { get; set; }
        [Required]
        [StringLength(55, MinimumLength = 5)]
        public string Address { get; set; }
        [Required]
        public int NeighborhoodId { get; set; }
        [Phone]
        public string Phone { get; set; }
        public Neighborhood Neighborhood { get; set; }
        public List<Dog> Dogs { get; set; }

    }
}
