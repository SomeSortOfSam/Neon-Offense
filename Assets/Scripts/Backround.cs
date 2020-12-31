using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Backround : MonoBehaviour
{
    public Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        StateManager.startNewLevelEvent += Scroll;
        StateManager.endNewLevelEvent += UnScroll;
    }

    private void UnScroll()
    {
        animator.SetTrigger("Stop");
    }

    private void Scroll()
    {
        animator.SetTrigger("Start");
    }
}
