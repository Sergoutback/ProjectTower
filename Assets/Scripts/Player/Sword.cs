using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour
{
    public bool CanTake = true;
    public int Damage = 1;
    private Rigidbody2D rb;
    [SerializeField]
    private PhysicsMaterial2D material2DAttack;
    [SerializeField]
    private PhysicsMaterial2D material2DIdle;
    private new CapsuleCollider2D collider2D;
    public Vector3 vel;
    private void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        collider2D = gameObject.GetComponent<CapsuleCollider2D>();
    }

    private void FixedUpdate()
    {
        if (!CanTake)
        {
            rb.velocity =vel;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if((collision.gameObject.layer == 8  || collision.gameObject.layer == 12) && !CanTake)
        {
            EndAtttack();
        }
        else if(collision.gameObject.layer == 11)
        {     
            rb.velocity = new Vector3(0, 0, 0);
            rb.freezeRotation = true;
            EndAtttack();
            rb.gravityScale = 10;
            collider2D.sharedMaterial = material2DIdle;
            gameObject.transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else if(collision.gameObject.tag == "Enemy" && !CanTake)
        {
            collision.gameObject.GetComponent<EnemyHealth>().TakeDamage(Damage);
            StartCoroutine(WaitBeforeAttack());
        }
        else if (collision.gameObject.layer == 13 && !CanTake)
        {
            collision.gameObject.GetComponent<EnemyHealth>().TakeDamage(Damage);
            StartCoroutine(WaitBeforeAttack());

        }
    }
    IEnumerator WaitBeforeAttack()
    {

        yield return new WaitForSeconds(0.1f);
        EndAtttack();
    }

    public void StartAttack()
    {
        collider2D.sharedMaterial = material2DAttack;
    }
    private void EndAtttack()
    {
        rb.gravityScale = 2f;
        Physics.IgnoreLayerCollision(7, 9, true);
        gameObject.layer = 9;
        CanTake = true;
      //  gameObject.transform.rotation = Quaternion.Euler(0, 0, 0);
        
       
        
    }
}
