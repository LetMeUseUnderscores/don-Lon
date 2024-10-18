using UnityEngine;

public class PlayBackgroundAudio : MonoBehaviour
{
    public static PlayBackgroundAudio instance;
    void Awake() {
        if(instance != null) {
            Destroy(gameObject);
        } else {
            instance = this;
        }
        DontDestroyOnLoad(gameObject);
    } 
}
