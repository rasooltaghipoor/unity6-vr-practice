using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance { get; private set; }

    [SerializeField] private AudioSource _musicSource;
    [SerializeField] private AudioSource _sfxSource;

    [Range(0f, 1f)] public float MusicVolume = 1f;
    [Range(0f, 1f)] public float SfxVolume = 1f;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        _musicSource.loop = true;
        _musicSource.playOnAwake = true;

        _sfxSource.loop = false;
        _sfxSource.playOnAwake = false;
    }

    public void PlayMusic(AudioClip clip)
    {
        if (clip == null) return;

        _musicSource.clip = clip;
        _musicSource.volume = MusicVolume;
        _musicSource.Play();
    }

    public void PlayEffect(AudioClip clip)
    {
        if (clip == null) return;

        _sfxSource.clip = clip;
        _sfxSource.volume = SfxVolume;
        _sfxSource.Play();
    }

    public void StopMusic()
    {
        _musicSource.Stop();
    }

    public void PauseMusic()
    {
        _musicSource.Pause();
    }

    public void ResumeMusic()
    {
        _musicSource.UnPause();
    }

    public void ToggleMusicMute()
    {
        _musicSource.mute = !_musicSource.mute;
    }

    public void PlaySfx(AudioClip clip)
    {
        if (clip == null) return;
        _sfxSource.PlayOneShot(clip, SfxVolume);
    }

    public void ToggleSfxMute()
    {
        _sfxSource.mute = !_sfxSource.mute;
    }
}
