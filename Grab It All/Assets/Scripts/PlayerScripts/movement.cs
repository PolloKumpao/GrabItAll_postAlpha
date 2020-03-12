using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum AnimatorNames
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

public class movement : MonoBehaviour
{
    private float speedX = 2f;
    private float speedZ = 2f;

    private float xMove =0;
    private float zMove = 0;

    bool once=true;

    private CharacterController pj;
    private PlayerStats stats;
    float moveHorizontal;
    float moveVertical;
    private Animator animator;

    public Transform direction;

    // Start is called before the first frame update
    void Start()
    {
        stats = GetComponent<PlayerStats>();
        pj = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();

        direction.position = transform.position - new Vector3(2, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (stats.canMove)
            PlayerMovement();

        if(moveHorizontal==0&&moveVertical==0)
        {
            animator.ResetTrigger("Walk");
            animator.SetTrigger("Idle");
            //direction.position = direction.position;

        }
        if (moveVertical>0 && moveHorizontal>0)
        {
            direction.position = transform.position + new Vector3(-2, 0, 2);
        }
        else if(moveVertical<0&&moveHorizontal<0)
        {
            direction.position = transform.position + new Vector3(2, 0, -2);
        }
        else if (moveVertical < 0 && moveHorizontal > 0)
        {
            direction.position = transform.position + new Vector3(2, 0, 2);
        }
        else if (moveVertical > 0 && moveHorizontal < 0)
        {
            direction.position = transform.position + new Vector3(-2, 0, -2);
        }

        else if (moveVertical>0)
        {
            direction.position = transform.position - new Vector3(2,0,0);
            animator.ResetTrigger("Idle");
            animator.SetTrigger("Walk");
        }
        else if(moveVertical<0)
        {
            direction.position = transform.position + new Vector3(2, 0, 0);
            animator.SetTrigger("Walk");
            animator.ResetTrigger("Idle");
        }

        else if(moveHorizontal>0)
        {
            direction.position = transform.position + new Vector3(0, 0, 2);
            animator.SetTrigger("Walk");
            animator.ResetTrigger("Idle");
        }
        else if(moveHorizontal<0)
        {
            direction.position = transform.position - new Vector3(0, 0, 2);
            animator.SetTrigger("Walk");
            animator.ResetTrigger("Idle");
        }
        transform.LookAt(direction);
    }

    void PlayerMovement()
    {
        moveHorizontal = Input.GetAxisRaw("Horizontal") * stats.speed;
        moveVertical = Input.GetAxisRaw("Vertical") * stats.speed;
        /*
        if(Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0 && this.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("Walk") == false)
        {
            this.GetComponent<Animator>().SetTrigger(AnimatiorNames.Walk.ToString());
        }
        else if(Input.GetAxisRaw("Horizontal") == 0 && Input.GetAxisRaw("Vertical") == 0 && this.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("Walk") == true)
        {
            this.GetComponent<Animator>().ResetTrigger(AnimatiorNames.Walk.ToString());
            this.GetComponent<Animator>().SetTrigger(AnimatiorNames.Idle.ToString());
        }
        */
        Vector3 moveH = new Vector3(0, 0, 1) * moveHorizontal;
        Vector3 moveV = new Vector3(-1,0,0) * moveVertical;

        pj.SimpleMove(moveV + moveH);

        if (Input.GetButton("Fire1"))
        {

        }
        if (Input.GetButton("Fire2"))
        {

        }
    }

}
