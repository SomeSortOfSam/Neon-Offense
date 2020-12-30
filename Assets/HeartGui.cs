using UnityEngine;
using UnityEngine.UI;

public class HeartGui : MonoBehaviour
{
    public Image[] hearts = new Image[3];

    private void Start()
    {
        Player.damageEvent += OnDamage;
    }

    private void OnDamage(int currentHealth)
    {
        for (int x = 0; x < hearts.Length; x++)
        {
            hearts[x].color = x < currentHealth ? Color.white : Color.black;
        }
    }
}
