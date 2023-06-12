using UnityEngine;

public class Winning : MonoBehaviour
{
    [SerializeField] GameObject WinScreen;
    [SerializeField] GameObject GameOver;
    bool allowPlaySound = true;
    bool HaveWon = false;
    AudioSource GameAudioSrc;
    AudioClip WinningSound;
    AudioClip LosingSound;
    MusicPlayerScript MusicPLAYER;
    private void Start() {
        GameAudioSrc = GetComponent<AudioSource>();
        WinningSound = Resources.Load<AudioClip>("Winning");
        LosingSound = Resources.Load<AudioClip>("GameOver");
        allowPlaySound = true;
        MusicPLAYER = GameObject.FindGameObjectWithTag("MusicPlayer").GetComponent<MusicPlayerScript>();
    }
    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.CompareTag("President"))
        {
            HaveWon = true;
            MusicPLAYER.StopPlayingMusic();
            if(allowPlaySound)
            {
                allowPlaySound = false;
                GameAudioSrc.volume = 1;
                GameAudioSrc.PlayOneShot(WinningSound);
            }
            WinScreen.SetActive(true);
            Time.timeScale = 0;
        }
    }
    private void Update() {
        if(!PresidentLiveDectector.presidentIsLive)
        {
            MusicPLAYER.StopPlayingMusic();
            if(allowPlaySound)
            {
                allowPlaySound = false;
                GameAudioSrc.volume = 0.59f;
                GameAudioSrc.PlayOneShot(LosingSound);
            }
            GameOver.SetActive(true);
            Time.timeScale = 0;
        }
        if(PresidentLiveDectector.presidentIsLive && !HaveWon)
        {
            GameOver.SetActive(false);
            Time.timeScale = 1;
        }
    }
}
