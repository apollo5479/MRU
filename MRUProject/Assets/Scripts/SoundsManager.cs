using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
//using UnityEngine.Random;

public class SoundsManager : MonoBehaviour
{
    public static SoundsManager Instance { get; private set; }

    [Header("Audio Sources")]
    public AudioSource musicSource; // For background music
    public AudioSource sfxSource; // For sound effects

    [Header("Music Library")]
    public AudioClip mainMenuMusic;
    public AudioClip gameplayMusic;
    public AudioClip bossMusic;

    [Header("SFX Library")]
    public AudioClip clickSFX;
    public AudioClip attackSFX;
    public AudioClip hitSFX;
    public AudioClip bigBoom;
    public AudioClip boom;
    public AudioClip swish;

    private string currentScene;
    private Coroutine fadeCoroutine;

    void Awake()
    {
        // Singleton pattern
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        // Ensure sources exist
        if (!musicSource) musicSource = gameObject.AddComponent<AudioSource>();
        if (!sfxSource) sfxSource = gameObject.AddComponent<AudioSource>();

        musicSource.loop = true;
        sfxSource.loop = false;

        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        currentScene = scene.name;
        PlaySceneMusic();
    }

    private void PlaySceneMusic()
    {
        AudioClip clipToPlay = null;

        switch (currentScene)
        {
            case "MainMenu":
                clipToPlay = mainMenuMusic;
                break;
            case "Game":
                clipToPlay = gameplayMusic;
                break;
            case "BossFight":
                //clipToPlay = bossMusic;
                break;
            default:
                return;
        }

        if (clipToPlay != musicSource.clip)
        {
            FadeToNewMusic(clipToPlay, 1f); // 1 second fade
        }
    }

    private void FadeToNewMusic(AudioClip newClip, float fadeTime)
    {
        if (fadeCoroutine != null) StopCoroutine(fadeCoroutine);

        fadeCoroutine = StartCoroutine(FadeMusicRoutine(newClip, fadeTime));
    }

    private IEnumerator FadeMusicRoutine(AudioClip newClip, float fadeTime)
    {
        float startVolume = musicSource.volume;

        // Fade out
        for (float t = 0; t < fadeTime; t += Time.deltaTime)
        {
            musicSource.volume = Mathf.Lerp(startVolume, 0, t / fadeTime);
            yield return null;
        }

        musicSource.clip = newClip;
        musicSource.Play();

        // Fade in
        for (float t = 0; t < fadeTime; t += Time.deltaTime)
        {
            musicSource.volume = Mathf.Lerp(0, startVolume, t / fadeTime);
            yield return null;
        }

        musicSource.volume = startVolume;
    }

    public void PlaySFX(AudioClip clip)
    {
        sfxSource.pitch = sfxSource.pitch + Random.Range(-0.5f, 0.5f);
        sfxSource.PlayOneShot(clip);
    }

    // Convenience methods
    public void PlayClick() => PlaySFX(clickSFX);
    public void PlayAttack() => PlaySFX(attackSFX);
    public void PlayHit() => PlaySFX(hitSFX);
}
