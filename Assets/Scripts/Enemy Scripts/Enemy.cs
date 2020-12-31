using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(AudioSource))]
public class Enemy : Rebounder
{
    public static List<Enemy> enemies = new List<Enemy>();

    public float idelShiftAmount;
    public int idelShiftDurration;
    public int idelShiftTimer;
    public int idelInBetweenDurration;
    public int idelInBetweenTimer;
    public float xPos;
    public float yPos;
    public Vector2 Origin
    {
        get
        {
            return new Vector2(xPos, yPos);
        }
        set
        {
            xPos = value.x;
            yPos = value.y;
        }
    }
    public bool shifted;
    public bool chargeing;

    public Rigidbody2D rigidbody;
    public AudioSource audioSource;
    public AudioClip deathSound;
    public virtual void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        Origin = transform.position;
        enemies.Add(this);
    }

    private void Update()
    {
        if (chargeing)
        {
            Charge();
        }
        else
        {
            Idel();
        }

    }

    public virtual void Idel()
    {
        idelInBetweenTimer++;
        if (idelInBetweenTimer > idelInBetweenDurration && !shifted)
        {
            idelShiftTimer++;
            if (idelShiftTimer > idelShiftDurration)
            {
                idelShiftTimer = 0;
                idelInBetweenTimer = 0;
                shifted = true;
            }
            rigidbody.velocity = GetVelocityFromIdelTimer();
        }
        else if (idelInBetweenTimer > idelInBetweenDurration && shifted)
        {
            chargeing = true;
        }
        else
        {
            rigidbody.velocity = Vector3.zero;
        }

    }

    private Vector3 GetVelocityFromIdelTimer()
    {
        switch (GetIdelStage(idelShiftTimer, idelShiftDurration))
        {
            case 0:
                return Origin - Origin + Vector2.left * idelShiftAmount;
            case 1:
                return Origin + Vector2.left * idelShiftAmount - Origin;
            case 2:
                return Origin - Origin + Vector2.right * idelShiftAmount;
            case 3:
                return Origin + Vector2.right * idelShiftAmount - Origin;
        }
        return Vector3.zero;

    }

    private static int GetIdelStage(int time, int fullDurration)
    {
        int quaterDurration = fullDurration / 4;
        int stageTime = quaterDurration;
        int stage = 0;
        while (stageTime <= fullDurration)
        {
            if (time < stageTime)
            {
                return stage;
            }
            else
            {
                stageTime += quaterDurration;
                stage++;
            }
        }
        return stage;
    }

    public virtual void Charge()
    {
        bool v = transform.position.y - yPos > .5f;
        rigidbody.velocity = v ? Vector2.down : Vector2.zero;
        if (!v)
        {
            chargeing = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Bullet bullet) && bullet.Friendly)
        {
            audioSource.PlayOneShot(deathSound);
            Destroy(gameObject);
        }
    }

    private void OnDestroy()
    {
        enemies.Remove(this);
        if (enemies.Count <= 0)
        {
            StateManager.Win();
        }
    }

    public override void OnDrawGizmosSelected()
    {
        base.OnDrawGizmosSelected();
        Gizmos.DrawLine(Origin + Vector2.left * idelShiftAmount, Origin + Vector2.right * idelShiftAmount);
    }
}
