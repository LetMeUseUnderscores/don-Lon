using UnityEngine;

public class AutoResizeHitbox : MonoBehaviour
{
    public SpriteRenderer sprite;
    public BoxCollider2D hitbox;
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        hitbox = GetComponent<BoxCollider2D>();

        if(sprite != null && hitbox != null) {
            hitbox.size = sprite.size;
            hitbox.offset = sprite.bounds.center - transform.position;
        }
    }
}
