namespace FairyShooter
{
    public class GameObjects
    {
        public GameObjects()
        {

        }
        public Fairy Fairy { get; set; }
        public ProjectileManager ProjectileManager { get; set; }
        public EnemyManager EnemyManager { get; set; }
        public CollisionManager CollisionManager { get; set; }
        public ExplosionManager ExplosionManager { get; set; }
    }
}