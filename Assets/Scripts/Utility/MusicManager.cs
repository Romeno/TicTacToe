using UnityEngine;
using System.Collections;


public enum MusicTheme
{
    None,
    MainMenu,
    Game,
    Max
}

public class MusicManager : MonoBehaviour
{
    #region Unity

    void Update()
    {
        //if (nowPlayingType == MusicTheme.MainMenu)
        //{
        //    float delta = nowPlaying.clip.length - nowPlaying.time;
        //    if (delta < 0.05f && !switching)
        //    {
        //        AudioUtil.FadeIn(mainMenuTheme[0], 0.1f);
        //        switching = true;
        //    }
        //}

        if (nowPlayingType == MusicTheme.Game)
        {
            float delta = nowPlaying.clip.length - nowPlaying.time;
            if (delta < 0.05f)
            {
                int nextThemeInd = NextThemeInd(gameThemeInd, gameTheme.Length);
                StartCoroutine(AudioUtil.FadeIn(mainMenuTheme[nextThemeInd], 0.1f));
                nowPlaying = mainMenuTheme[nextThemeInd];
                //switching = true;
            }
        }
    }

    #endregion

    private int NextThemeInd(int nowPlayingTheme, int length)
    {
        if (nowPlayingTheme + 1 == length)
        {
            return 0;
        }
        else
        {
            return nowPlayingTheme + 1;
        }
    }

    public void SwitchToMainMenuTheme()
    {
        if (nowPlaying)
        {
            AudioUtil.FadeOut(nowPlaying, 1.0f);
        }
        StartCoroutine(AudioUtil.FadeIn(mainMenuTheme[0], 1.0f));

        nowPlaying = mainMenuTheme[0];
        nowPlayingType = MusicTheme.MainMenu;
    }

    public void SwitchToGameTheme()
    {
        if (nowPlaying)
        {
            AudioUtil.FadeOut(nowPlaying, 1.0f);
        }

        StartCoroutine(AudioUtil.FadeIn(gameTheme[0], 1.0f));

        nowPlaying = gameTheme[0];
        nowPlayingType = MusicTheme.Game;
        gameThemeInd = 0;
    }

    public AudioSource[] mainMenuTheme;
    public AudioSource[] gameTheme;

    private AudioSource nowPlaying = null;
    private MusicTheme nowPlayingType = MusicTheme.None;

    private bool switching = false;
    private int gameThemeInd = -1;
}
