using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveAround : MonoBehaviour
{
    [SerializeField] private float enemySpeed;
    [SerializeField] private float turnSpeed;
    [SerializeField] private Transform[] patrolPoint;
    private int currentPoint;
    private Rigidbody rb;
    private Transform target;
    private Transform enemy;
    private bool isAttack;



    private void Awake()
    {
        rb = transform.GetComponentInChildren<Rigidbody>();
        enemy = rb.transform;
    }
    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.Find("Player").transform;
        InvokeRepeating("FindTarget", 0f, 2f);

    }

    // Update is called once per frame
    void Update()
    {
        if (isAttack)
        {
            Move(target);
            enemySpeed = 0.01f;
            turnSpeed = 2f;
        }
        else
        {

            enemySpeed = 0.001f;
            turnSpeed = 1f;
            Move(patrolPoint[currentPoint]);
        }
    }
    private void FindTarget()
    {
        if (Vector3.Distance(enemy.position, target.position) < 20)
        {
            isAttack = true;

        }
        else
        {
            isAttack = false;
            if (Vector3.Distance(enemy.position, patrolPoint[currentPoint].position) < 10)
            {
                currentPoint++;

                if (currentPoint >= patrolPoint.Length)
                {
                    currentPoint = 0;
                }
            }
        }
    }
    private void Move(Transform myTarget)
    {
        Vector3 targetDirection = myTarget.position - enemy.position;
        targetDirection = new Vector3(targetDirection.x, 0f, targetDirection.z);
        float singleStep = turnSpeed * Time.deltaTime;
        Vector3 look = Vector3.RotateTowards(enemy.forward, targetDirection, singleStep, 0f);
        enemy.rotation = Quaternion.LookRotation(look);
        enemy.Translate(Vector3.forward * enemySpeed);
    }
}