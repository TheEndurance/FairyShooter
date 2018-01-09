/* 
 * Programmer: Rawa Jalal
 * Revision History:
 *          01/03/2017: Created
 *          
 */
namespace FairyShooter
{
    /// <summary>
    /// Holds all of the game objects
    /// </summary>
    public class GameObjects
    {

        public Fairy Fairy { get; set; }
        public ProjectileManager ProjectileManager { get; set; }
        public EnemyManager EnemyManager { get; set; }
        public CollisionManager CollisionManager { get; set; }
        public ExplosionManager ExplosionManager { get; set; }
        public SoundManager SoundManager { get; set; }
    }
}