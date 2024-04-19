﻿using RunGroopWebApp.Data.Enum;
using RunGroopWebApp.Models;

namespace RunGroopWebApp.ViewModels
{
    public class CreateClubViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public AddressModel Address { get; set; }
        public IFormFile Image { get; set; }
        public ClubCategoryEnum ClubCategory { get; set; }
    }
}
