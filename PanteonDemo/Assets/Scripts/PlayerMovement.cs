 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 1f;
    private float swerveInputDir;
    private Vector3 moveVector;
    private Animator anim;
    private Player player;
    private SwerveInputSystem swerveInputSystem;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        player = GetComponent<Player>();
        swerveInputSystem = GetComponent<SwerveInputSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    void Move()
    {
        if (!player.isFall && !player.onPaint)
        {
            //inputDirection = Input.GetAxis("Horizontal");
            swerveInputDir = swerveInputSystem.moveFactorX;
            moveVector = new Vector3(swerveInputDir, 0, 0);
            transform.Translate(Vector3.forward * Time.deltaTime * speed + moveVector * Time.deltaTime * .2f);
            anim.SetBool("isRunning", true);

            if (gameObject.transform.parent != null)
            {
               
               anim.SetBool("isForwarding", true);
            }
            else
            {
                 anim.SetBool("isForwarding", false);
            }
        }
    }
}
