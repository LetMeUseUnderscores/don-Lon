using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Transform target;
    public float yOffset = 5f;
    public float xOffset = 5f;
    void Update()
    {
        transform.position = new Vector3(target.position.x + xOffset, target.position.y + yOffset, transform.position.z);
    }
}
