using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

enum AnimatiorNames
{
    Idle = 0,
    Walk = 1,
    Run = 2,
    Steal = 3,
    Death = 4,
    Kill = 5,
    Talk = 6,
    Throw = 7
}

public class patrol : MonoBehaviour
{
    public enum State { NPC, PATROL };
    public float speed;

    public bool alarmOn = false;

    public float fieldOfViewAngle = 110f;
    public bool playerInSight;

    public State state;

    private PlayerStats stats;
    private enemyScript enemy;

    private float waitTime;
    private float resetTimer = 15f;
    public float startWaitTime;

    public NavMeshAgent agent;
    public GameObject player;
    private GameObject throwedObject;

    public GameObject alarma;
    public Transform[] moveSpots;
    private int actualSpot = 0;

    public Transform moveSpot;
    public float minX;
    public float minZ;
    public float maxX;
    public float maxZ;

    private float x;
    private float z;



    void Start()
    {
        waitTime = startWaitTime;
        x = Random.Range(minX, maxX);
        z = Random.Range(minZ, maxZ);
        if (moveSpot != null)
            moveSpot.transform.position = new Vector3(Mathf.Clamp(x, minX, maxX), 0, Mathf.Clamp(z, minZ, maxZ));

        stats = player.GetComponent<PlayerStats>();
        enemy = GetComponent<enemyScript>();

    }

    void Update()
    {

        switch (state)
        {
            case State.NPC:
                if(agent.velocity.x>0|| agent.velocity.x < 0 || agent.velocity.z > 0 || agent.velocity.z < 0)
                {
                    GetComponent<Animator>().ResetTrigger("Idle");
                    GetComponent<Animator>().SetTrigger("Walk");
                }
                else
                {
                    GetComponent<Animator>().ResetTrigger("Walk");
                    GetComponent<Animator>().SetTrigger("Idle");
                }

                agent.SetDestination(moveSpot.transform.position);

                if (Vector2.Distance(transform.position, moveSpot.transform.position) < 1f)
                {
                    if (waitTime <= 0)
                    {
                        x = Random.Range(minX, maxX);
                        z = Random.Range(minZ, maxZ);
                        moveSpot.transform.position = new Vector3(Mathf.Clamp(x, minX, maxX), 0, Mathf.Clamp(z, minZ, maxZ));
                        //moveSpot.transform.position = new Vector3(Random.Range(minX, maxX), 0, Random.Range(minZ, maxZ));
                        waitTime = startWaitTime;

                    }
                    else
                    {
                        waitTime -= Time.deltaTime;
                    }
                }
                resetTimer -= Time.deltaTime;
                if (resetTimer <= 0)
                {
                    moveSpot.transform.position = new Vector3(Random.Range(minX, maxX), 0, Random.Range(minZ, maxZ));
                    resetTimer = 10f;
                }

                break;

            case State.PATROL:
                if (enemy.alive)
                {
                    if (agent.velocity.x > 0 || agent.velocity.x < 0 || agent.velocity.z > 0 || agent.velocity.z < 0)
                    {
                        GetComponent<Animator>().ResetTrigger("Idle");
                        GetComponent<Animator>().SetTrigger("Walk");
                    }
                    else
                    {
                        GetComponent<Animator>().ResetTrigger("Walk");
                        GetComponent<Animator>().SetTrigger("Idle");
                    }
                    playerInSight = InFov(transform, player.transform, fieldOfViewAngle, stats.detectionSightRange);

                    if (playerInSight)
                    {
                        stats.watched = true;
                    }
                    else
                        stats.watched = false;

                   /* if (stats.makingNoise)
                    {
                        float dist = Vector3.Distance(player.transform.position, transform.position);
                        if (dist < stats.detectionNoiseRange)
                        {
                            agent.SetDestination(player.transform.position);
                        }
                        else
                        {
                            agent.SetDestination(moveSpots[actualSpot].position);
                            if (Vector2.Distance(transform.position, moveSpots[actualSpot].position) < 1f)
                            {
                                if (waitTime <= 0)
                                {
                                    actualSpot++;
                                    if (actualSpot >= moveSpots.Length)
                                        actualSpot = 0;

                                    waitTime = startWaitTime;
                                }
                                else
                                {
                                    waitTime -= Time.deltaTime;
                                }
                            }
                        }
                    }*/
                    if (stats.state == PlayerStats.States.WANTED)
                    {
                        agent.SetDestination(player.transform.position);
                        if (Vector2.Distance(transform.position, player.transform.position) < 1f)
                        {
                            stats.state = PlayerStats.States.CAUGHT;
                        }
                    }
                    else if (playerInSight && stats.state == PlayerStats.States.STEALING)
                    {
                        agent.SetDestination(player.transform.position);
                        if (Vector2.Distance(transform.position, player.transform.position) < 1f)
                        {
                            stats.state = PlayerStats.States.CAUGHT;
                        }
                    }
                    else if (alarmOn)
                    {
                        agent.SetDestination(alarma.transform.position);                        
                        if (Vector3.Distance(transform.position, alarma.transform.position)<2f)
                        {
                            alarmOn = false;
                        }
                    }
                    else
                    {
                        agent.SetDestination(moveSpots[actualSpot].position);
                        if (Vector2.Distance(transform.position, moveSpots[actualSpot].position) < 1f)
                        {
                            if (waitTime <= 0)
                            {
                                actualSpot++;
                                if (actualSpot >= moveSpots.Length)
                                    actualSpot = 0;

                                waitTime = startWaitTime;
                            }
                            else
                            {
                                waitTime -= Time.deltaTime;
                            }
                        }
                    }
                }
                else
                {
                    GetComponent<Animator>().SetTrigger(AnimatiorNames.Death.ToString());
                    agent.enabled = false;
                }

                break;
        }
    }

    public static bool InFov(Transform CheckingObject, Transform target, float maxAngle, float radius)
    {
        Collider[] overlaps = new Collider[1000];
        int count = Physics.OverlapSphereNonAlloc(CheckingObject.position, radius, overlaps);
        for (int i = 0; i < count + 1; i++)
        {
            if (overlaps[i] != null)
            {
                if (overlaps[i].transform == target)
                {
                    Vector3 direction = (target.position - CheckingObject.position).normalized;
                    direction.y *= 0;

                    float angle = Vector3.Angle(CheckingObject.forward, direction);
                    if (angle < maxAngle)
                    {
                        Ray ray = new Ray(CheckingObject.position, target.position - CheckingObject.position);
                        RaycastHit hit;

                        if (Physics.Raycast(ray, out hit, radius))
                        {
                            if (hit.transform == target)
                                return true;
                        }
                    }
                }
            }
        }
        return false;

    }

    bool opened = false;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "interactable")
        {
            Animator anim = other.gameObject.GetComponent<Animator>();
            ObjectID ID = other.gameObject.GetComponent<ObjectID>();
            if (ID.ID == 100)
            {
                if (!opened)
                {
                    anim.SetBool("open", true);
                }
                else
                    anim.SetBool("open", false);

                opened = !opened;
            }
        }
    }
}
