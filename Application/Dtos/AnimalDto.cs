﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dtos
{
    public class AnimalDto
    {
        public string? Name { get; set; }
        public string? Type { get; set; }
        public bool LikesToPlay { get; set; }
        public bool CanFly { get; set; }
        public bool LikeToFtech { get; set; }
    }
}
