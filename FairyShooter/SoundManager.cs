/* 
 * Programmer: Rawa Jalal
 * Revision History:
 *          01/03/2017: Created
 *          
 */
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Media;

namespace FairyShooter
{
    /// <summary>
    /// Manages the game sounds
    /// </summary>
    public class SoundManager
    {
        public Song BackgroundMusic { get; set; }
        public SoundEffect LaserEffect { get; set; }
        public SoundEffect BoomEffect { get; set; }
        public SoundEffect GameOverEffect { get; set; }

        /// <summary>
        /// Sound manager constructor
        /// </summary>
        /// <param name="content">Game content</param>
        public SoundManager(ContentManager content)
        {
            BackgroundMusic = content.Load<Song>(@"sounds\gamemusic");
            LaserEffect = content.Load<SoundEffect>(@"sounds\laser");
            BoomEffect = content.Load<SoundEffect>(@"sounds\boom");
            GameOverEffect = content.Load<SoundEffect>(@"sounds\gameover");
        }

        /// <summary>
        /// Plays background music
        /// </summary>
        public void PlayBackgroundMusic()
        {
            if (MediaPlayer.GameHasControl)
            {
                MediaPlayer.Play(BackgroundMusic);
                MediaPlayer.IsRepeating = true;
            }
        }

        /// <summary>
        /// Players shooting laser sound effect
        /// </summary>
        public void PlayLaserEffect()
        {
            LaserEffect.Play();
        }

        /// <summary>
        /// Plays a boom sound effect
        /// </summary>
        public void PlayBoomEffect()
        {
            BoomEffect.Play();
        }

        /// <summary>
        /// Stops the background music from playing
        /// </summary>
        public void StopPlayingBackgroundMusic()
        {
            MediaPlayer.Stop();
        }

        /// <summary>
        /// Plays a game over sound effect
        /// </summary>
        public void PlayGameOverEffect()
        {
            GameOverEffect.Play();
        }
    }
}