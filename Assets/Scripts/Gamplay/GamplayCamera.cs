using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class GamplayCamera : MonoBehaviour
{
    public static GamplayCamera instance;
    new public Camera camera;
    public Bounds CameraBounds
    {
        get
        {
            float height = camera.orthographicSize * 2;
            float width = camera.aspect * height;
            return new Bounds((Vector2)transform.position, new Vector2(width, height));
        }
        set
        {
            camera.orthographicSize = BoundsToOrithigraphicSize(value);
            transform.position = new Vector3(value.center.x, value.center.y, -10);
        }
    }
    private float BoundsToOrithigraphicSize(Bounds value)
    {
        float orthigraphicSize = value.extents.y;
        if (value.size.x > value.size.y)
        {
            orthigraphicSize = value.extents.x / camera.aspect;
        }
        return orthigraphicSize;
    }
    // Start is called before the first frame update
    public void Start()
    {
        instance = this;
        camera = GetComponent<Camera>();
        Player.damageEvent += Shake;
    }

    private void Shake(int obj)
    {
        StartCoroutine(ShakeCorutione());
    }

    IEnumerator ShakeCorutione()
    {
        yield return null;
    }
}
