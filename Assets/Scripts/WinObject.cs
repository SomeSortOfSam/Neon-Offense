using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Collider2D),typeof(SpriteRenderer))]
public class WinObject : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent(out Player player))
        {
            player.animator.SetTrigger("Win");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
