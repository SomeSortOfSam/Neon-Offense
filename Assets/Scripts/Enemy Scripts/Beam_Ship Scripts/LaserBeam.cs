using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class LaserBeam : MonoBehaviour
{
    AudioSource source;

    public AudioClip warmUpSound;
    public AudioClip fireingSound;

    public Vector2 direction;

    public SpriteRenderer headRenderer;
    public SpriteRenderer beamRenderer;
    public BoxCollider2D beamCollider;

    public Sprite warningHeadSprite;
    public Sprite warningBeamSprite;
    public int warningDurration;
    public int flashCycleDurration;
    public float beamDurration;

    public Sprite laserHead;
    public Sprite laserBeam;

    private void Start()
    {
        source = GetComponent<AudioSource>();
    }

    internal IEnumerator StartLaser()
    {
        headRenderer.sprite = warningHeadSprite;
        beamRenderer.sprite = warningBeamSprite;
        source.clip = warmUpSound;
        source.Play();
        int time = 0;
        while (time < warningDurration)
        {
            headRenderer.color = Color.Lerp(Color.white, Color.clear, time % flashCycleDurration);
            beamRenderer.color = Color.Lerp(Color.white, Color.clear, time % flashCycleDurration);
            time++;
            yield return null;
        }
        source.clip = fireingSound;
        source.Play();
        headRenderer.color = Color.white;
        beamRenderer.color = Color.white;
        headRenderer.sprite = laserHead;
        beamRenderer.sprite = laserBeam;
        beamCollider.enabled = true;
        yield return new WaitForSeconds(beamDurration);
        beamCollider.enabled = false;
        headRenderer.color = Color.clear;
        beamRenderer.color = Color.clear;
        source.Stop();
    }
}
