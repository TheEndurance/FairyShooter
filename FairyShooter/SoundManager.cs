using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Media;

namespace FairyShooter
{
    public class SoundManager
    {
        public Song BackgroundMusic { get; set; }
        public SoundEffect LaserEffect { get; set; }
        public SoundEffect BoomEffect { get; set; }
        public SoundEffect GameOverEffect { get; set; }

        public SoundManager(ContentManager content)
        {
            BackgroundMusic = content.Load<Song>(@"sounds\gamemusic");
            LaserEffect = content.Load<SoundEffect>(@"sounds\laser");
            BoomEffect = content.Load<SoundEffect>(@"sounds\boom");
            GameOverEffect = content.Load<SoundEffect>(@"sounds\gameover");
        }

        public void PlayBackgroundMusic()
        {
            if (MediaPlayer.GameHasControl)
            {
                MediaPlayer.Play(BackgroundMusic);
                MediaPlayer.IsRepeating = true;
            }
        }

        public void PlayLaserEffect()
        {
            LaserEffect.Play();
        }

        public void PlayBoomEffect()
        {
            BoomEffect.Play();
        }

        public void StopPlayingBackgroundMusic()
        {
            MediaPlayer.Stop();
        }

        public void PlayGameOverEffect()
        {
            GameOverEffect.Play();
        }
    }
}