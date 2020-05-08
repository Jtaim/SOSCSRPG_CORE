using Engine.Models;

namespace Engine.ViewModels
{
    public class GameSession
    {
        public Player CurrentPlayer { get; set; }
        public Location CurrentLocation { get; set; }

        public GameSession()
        {
            CurrentPlayer = new Player {
                Name = "James",
                CharacterClass = "Fighter",
                HitPoints = 10,
                Gold = 1000000,
                ExperiencePoints = 0,
                Level = 1
            };

            CurrentLocation = new Location {
                Name = "Home",
                XCooordinate = 0,
                YCooordinate = -1,
                Description = "This is your house.",
                ImageName = "/Engine;component/Images/Locations/Home.png"
            };
        }
    }
}
