using UnityEngine;
using BallController;
[RequireComponent(typeof(AudioSource))]
public class AudioScript : MonoBehaviour
{
    [SerializeField] private Ball _ball;
    [SerializeField] private AudioClip _fixedClip, _touchedClip;
    private AudioSource _audioSource;
    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        _ball.OnFixed += PlayFixedSound;
        _ball.OnTouched += PlayTouchedSound;
    }
    private void PlayFixedSound()
    {
        PlaySound(_fixedClip);
    }
    private void PlayTouchedSound()
    {
        PlaySound(_touchedClip);
    }
    private void PlaySound(AudioClip clip)
    {
        _audioSource.PlayOneShot(clip);
    }
    private void OnDestroy()
    {
        _ball.OnFixed -= PlayFixedSound;
        _ball.OnTouched -= PlayFixedSound;
    }
}
