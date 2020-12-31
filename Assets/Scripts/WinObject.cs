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
        StateManager.winEvent += Activate;
        StateManager.endNewLevelEvent += Deactivate;
    }

    private void Activate()
    {
        gameObject.SetActive(true);
    }

    private void Deactivate()
    {
        gameObject.SetActive(false);
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
