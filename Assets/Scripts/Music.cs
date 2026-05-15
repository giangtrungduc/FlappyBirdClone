using UnityEngine;

public class Music : MonoBehaviour
{
    public static Music Instance;
    public AudioClip wingClip;
    public AudioClip hitClip;
    public AudioClip pointClip;
    public AudioClip dieClip;

    public AudioSource aus;
    public bool isToggle { get; private set; }
    private void Awake()
    {
        if(Instance == null) Instance = this;
        else Destroy(gameObject);
        isToggle = true;
    }

    public void PlayWingClip()
    {
        if(wingClip != null) PlayClip(wingClip);
    }
    public void PlayHitClip()
    {
        if(hitClip != null) PlayClip(hitClip);
    }
    public void PlayPointClip()
    {
        if(pointClip != null) PlayClip(pointClip);
    }
    public void PlayDieClip()
    {
        if(dieClip != null) PlayClip(dieClip);
    }
    public void SetVolume()
    {
        if(aus != null)
        {
            isToggle = !isToggle;
            aus.volume = isToggle ? 1f : 0f;
        }
    }
    private void PlayClip(AudioClip clip)
    {
        if(aus != null)
        {
            aus.PlayOneShot(clip);
        }
    }
}
