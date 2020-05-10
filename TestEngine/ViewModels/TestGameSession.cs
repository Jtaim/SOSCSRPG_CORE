using Engine.ViewModels;
using Xunit;

namespace TestEngine.ViewModels
{
    public class TestGameSession
    {
        [Fact]
        public void TestCreateGameSession()
        {
            GameSession gameSession = new GameSession();

            Assert.NotNull(gameSession.CurrentPlayer);
            Assert.Equal("Town square", gameSession.CurrentLocation.Name);
        }

        [Fact]
        public void TestPlayerMovesHomeAndIsCompletelyHealedOnKilled()
        {
            GameSession gameSession = new GameSession();

            gameSession.CurrentPlayer.TakeDamage(999);

            Assert.Equal("Home", gameSession.CurrentLocation.Name);
            Assert.Equal(gameSession.CurrentPlayer.Level * 10, gameSession.CurrentPlayer.CurrentHitPoints);
        }
    }
}
