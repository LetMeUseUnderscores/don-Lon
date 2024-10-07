using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Transform mainCamera;
    public Transform player;
    public float yOffset = 5f;
    void Update()
    {
        mainCamera.position = new Vector3(player.position.x, player.position.y + yOffset, mainCamera.position.z);
    }
}
