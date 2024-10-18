using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public Canvas canvas;
    public GameObject confirmationButton;
    public static PauseMenu instance;
    void Awake() {
        if(instance != null) {
            Destroy(gameObject);
        } else {
            instance = this;
        }
        DontDestroyOnLoad(gameObject);
    }
    void Start()
    {
        canvas = GetComponent<Canvas>();
        confirmationButton.SetActive(false);
        canvas.enabled = false;
    }
    void Update() {
        if(Input.GetKeyDown(KeyCode.Escape)) {
            canvas.enabled = !canvas.enabled;
            confirmationButton.SetActive(false);
        }
        if(canvas.enabled) {
            Time.timeScale = 0;
        } else {
            Time.timeScale = 1;
        }
    }

    public void onContinuePress() {
        canvas.enabled = false;
    }

    public void onQuitPress() {
        confirmationButton.SetActive(true);
    }

    public void onConfirm() {
        Application.Quit();
    }

}
