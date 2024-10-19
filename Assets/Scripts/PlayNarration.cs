using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class PlayNarration : MonoBehaviour
{
    public Transform player;
    public float playerPositionToPlay = 0;
    private bool isPlayed = false;
    void Update()
    {
        if(!isPlayed && player.transform.position.x > playerPositionToPlay)
        {
            GetComponent<AudioSource>().Play();
            isPlayed = true;
        }
    }
}
