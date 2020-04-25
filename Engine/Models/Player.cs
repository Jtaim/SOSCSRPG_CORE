using System;
using System.Collections.Generic;
using System.Text;

namespace Engine.Models
{
    class Player
    {
        string Name { get; set; }
        string CharaterClass { get; set; }
        int HitPoints { get; set; }
        int ExperiencePoints { get; set; }
        int Level { get; set; }
        int Gold { get; set; }
    }
}
