using System;
using System.Media;

namespace Lægeklinik.Lyde;

internal class Lydafspiller
{
    private SoundPlayer soundPlayer;

    public Lydafspiller(string audioFilePath)
    {
        soundPlayer = new SoundPlayer(audioFilePath);
    }

    public void PlayBackgroundMusic()
    {
        soundPlayer.PlayLooping();
    }

    public void StopBackgroundMusic()
    {
        if (soundPlayer != null && soundPlayer.IsPlaying)
        {
            soundPlayer.Stop();
        }
    }
}
