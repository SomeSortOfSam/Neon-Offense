using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class IntroCinimatic : MonoBehaviour
{
    public List<Sprite> sprites = new List<Sprite>();
    public bool locked;
    public bool endGame;
    public int index;
    public Image image;
    // Start is called before the first frame update
    void Start()
    {
        image = GetComponent<Image>();
        StartCoroutine(StartingCorutine());
    }

    private IEnumerator StartingCorutine()
    {
        if (sprites.Count >= 1)
        {
            locked = true;
            image.sprite = sprites[0];
            image.transform.localScale = Vector3.zero;
            image.color = Color.black;
            while (image.transform.localScale != Vector3.one)
            {
                image.transform.localScale += Vector3.one * .05f;
                image.color = Color.white * image.transform.localScale.x;
                yield return null;
            }
            locked = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(!locked && Input.GetMouseButtonDown(0))
        {
            if (sprites.Count > index + 1)
            {
                StartCoroutine(ContinueCorutine());
            }
            else
            {
                image.color = Color.black;
                if (endGame)
                {
                    Application.Quit();
                }
                else
                {
                    SceneManager.LoadSceneAsync(1);
                }
            }
        }
    }

    private IEnumerator ContinueCorutine()
    {
        locked = true;
        index++;
        image.sprite = sprites[index];
        image.color = Color.black;
        float time = 0;
        while (image.color != Color.white)
        {
            time += .05f;
            image.color = Color.white * time;
            yield return null;
        }
        locked = false;
    }
}
