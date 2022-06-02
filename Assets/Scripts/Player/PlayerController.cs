using System.Collections;
using System.Collections.Generic;
using CodeMVC.UserInput;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private bool RunOrAttack = true;
    [Header("Controll Options")]

    [SerializeField] private bool CanRun = true;
    [SerializeField] private bool CanJump = true;
    [SerializeField] private bool CanSit = true;
    [SerializeField] private float Speed;
    [SerializeField] private float JumpForce;
    
    [Header("Needs for jumps")]
    [SerializeField] private float JumpReload;
    [SerializeField] private float checkRadius;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask whatIsGround;
    [SerializeField] private bool isGrounded;
    
    [Header("Needible GO")]
    [SerializeField] private Joystick joystick;
    
    private Animator anim;
    private Rigidbody2D rb;
    private bool facingRight = true;
    private static float moveInput = 0;

    [Header("Attack Options")]
    [SerializeField] private LineRenderer line;
    [SerializeField] private LayerMask RayMask;
    
    private PlayerBullet playerBullet;
    
    void Start()
    {
        line.enabled = false;
        Time.timeScale = 1f;
        Time.fixedDeltaTime = 0.02f;
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        playerBullet = GetComponent<PlayerBullet>();
    }
    
    void FixedUpdate()
    {
            isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);     
        if (RunOrAttack)
        {
            if (joystick.Horizontal > 0.1f)
            {
                moveInput = 1;
            }
            else if (joystick.Horizontal < -0.1f)
            {
                moveInput = -1;
            }
            else
            {
                moveInput = 0;
            }

            if (joystick.Vertical > 0.7f && CanJump)
            {
                JumpStart();
            }
            else if (joystick.Vertical < -0.7f && CanSit)
            {

            }

        }
        else
        {
            moveInput = 0;          
            Ray2D ray =new Ray2D (gameObject.transform.position, new Vector2( joystick.Horizontal * 10, joystick.Vertical * 10) );
            RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction,100f, RayMask);
           
            
           

            if (joystick.Horizontal==0 && joystick.Vertical==0)
            {
               // line.enabled = false;
            }
            else if (hit)
            {
                line.enabled = true;
                line.SetPosition(0, ray.origin);
                line.SetPosition(1, hit.point);               
            }
            else
            {
                line.enabled = true;
                line.SetPosition(0, ray.origin);
                line.SetPosition(1, new Vector2(joystick.Horizontal * 100, joystick.Vertical * 100));
            }
        }
        rb.velocity = new Vector2(Mathf.Round(moveInput)*Speed, rb.velocity.y);

        if (facingRight == false && joystick.Horizontal > 0)
            {

                Flip();
            }
            else if (facingRight == true && joystick.Horizontal < 0)
            {

                Flip();
            }
        
    }
    public void Flip()
    {
        facingRight = !facingRight;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }
    public void JumpStart()
    {
        if (isGrounded)
        {
            rb.velocity =Vector2.up * JumpForce;
            CanJump = false;
            StartCoroutine("JumpCor");
        }
    }
    IEnumerator JumpCor()
    {
        yield return new WaitForSeconds(JumpReload);
        CanJump = true;
    }

    public void ChangeState()
    {
        if (playerBullet.InHand)
        {
            RunOrAttack = !RunOrAttack;
            if (RunOrAttack)
            {
                  playerBullet.Attack(line.GetPosition(0), line.GetPosition(1));

                line.enabled = false;
                Time.timeScale = 1f;
                Time.fixedDeltaTime = 0.02f;
            }
            else
            {
                Time.timeScale = 0.1f;
                Time.fixedDeltaTime = 0.02f * 0.1f;
            }
        }
    }
}
