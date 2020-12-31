using UnityEngine;

[RequireComponent(typeof(Collider2D),typeof(SpriteRenderer))]
public class WinObject : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public Collider2D collider;
    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        collider = GetComponent<Collider2D>();
        StateManager.winEvent += delegate { gameObject.SetActive(true); };
        StateManager.endNewLevelEvent += delegate { gameObject.SetActive(false); };
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent(out Player player))
        {
            player.animator.SetTrigger("Win");
            StateManager.LoadNextScene();
        }
    }
}
