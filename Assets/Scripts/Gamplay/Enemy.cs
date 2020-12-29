using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

[RequireComponent(typeof(Rigidbody2D))]
public class Enemy : Rebounder
{
    public static Action EnemyChargeStartEvent;
    public static Queue<Enemy> enemies = new Queue<Enemy>();

    public float idelShiftAmount;
    public int idelShiftDurration;
    int idelShiftTimer;
    public int idelInBetweenDurration;
    int idelInBetweenTimer;
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

    public bool Chargeing { get; private set; }
    new public Rigidbody2D rigidbody;
    private void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        Origin = transform.position;
        enemies.Enqueue(this);
        if(EnemyChargeStartEvent == null)
        {
            EnemyChargeStartEvent += OnEnemyStartCharge;
        }
    }

    private static void OnEnemyStartCharge()
    {
        Enemy enemy = null;
        while(enemy == null)
        {
            if (enemies.Count <= 0)
            {
                return;
            }
            enemy = enemies.Dequeue();
        }
        enemy.StartCharge();
        enemies.Enqueue(enemy);
    }

    private void StartCharge()
    {
        Chargeing = true;
    }

    private void Update()
    {
        if (Chargeing)
        {
            Charge();
        }
        else
        {
            Idel();
        }
        
    }

    private void Idel()
    {
        idelInBetweenTimer++;
        if(idelInBetweenTimer > idelInBetweenDurration)
        {
            idelShiftTimer++;
            if(idelShiftTimer > idelShiftDurration)
            {
                idelShiftTimer = 0;
                idelInBetweenTimer = 0;
            }
            transform.position = GetPositionFromIdelTimer();
        }
    }

    private Vector3 GetPositionFromIdelTimer()
    {
        switch (GetIdelStage(idelShiftTimer, idelShiftDurration))
        {
            case 0:
                return Vector3.Lerp(Origin,Origin + Vector2.left * idelShiftAmount,Mathf.Lerp(0f, idelShiftDurration/4f,idelShiftTimer));
            case 1:
                return Vector3.Lerp(Origin + Vector2.left * idelShiftAmount, Origin, Mathf.Lerp(idelShiftDurration / 4f, idelShiftDurration / 2f, idelShiftTimer));
            case 2:
                return Vector3.Lerp(Origin, Origin + Vector2.right * idelShiftAmount, Mathf.Lerp(idelShiftDurration / 2f, (idelShiftDurration / 4f) * 3f, idelShiftTimer));
            case 3:
                return Vector3.Lerp(Origin + Vector2.right * idelShiftAmount, Origin, Mathf.Lerp((idelShiftDurration / 4f) * 3f, idelShiftDurration, idelShiftTimer));
        }
        return Origin;

    }

    private static int GetIdelStage(int time, int fullDurration)
    {
        int quaterDurration = fullDurration / 4;
        int stageTime = quaterDurration;
        int stage = 0;
        while (stageTime <= fullDurration)
        {
            if(time < stageTime)
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

    private void Charge()
    {
        bool v = transform.position.y - yPos > .5f;
        rigidbody.velocity = v ? Vector2.down : Vector2.zero;
        if (!v)
        {
            Chargeing = false;
        }
    }

    public override void OnDrawGizmosSelected()
    {
        base.OnDrawGizmosSelected();
        Gizmos.DrawLine(Origin + Vector2.left * idelShiftAmount, Origin + Vector2.right * idelShiftAmount);
    }
}

#if UNITY_EDITOR
[CustomEditor(typeof(Enemy))]
public class EnemyEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        GUI.enabled = false;
        GUILayout.Toggle(((Enemy)target).Chargeing, "Chargeing");
        GUI.enabled = true;
        if (GUILayout.Button("Charge"))
        {
            Enemy.EnemyChargeStartEvent?.Invoke();
        }
    }
}
#endif
