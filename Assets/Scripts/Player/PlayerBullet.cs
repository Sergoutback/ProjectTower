using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{

    public bool InHand = false;
    private Sword SwordGO;
    [SerializeField]
    private GameObject swordTr;
    [SerializeField]
    private float BulletSpeed;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "PlayerBullet")
        {
            if (collision.gameObject.GetComponent<Sword>().CanTake &&! InHand) {
                Physics2D.IgnoreLayerCollision(6, 9, true);
                InHand = true;
                SwordGO = collision.gameObject.GetComponent<Sword>();
                SwordGO.gameObject.SetActive(false);
                swordTr.gameObject.SetActive(true);
            }
        }
        
    }

    public void Attack(Vector3 Startpos, Vector3 Endpos)
    {
        swordTr.gameObject.SetActive(false);
        Physics2D.IgnoreLayerCollision(7, 9, false);
        InHand = false;
        Physics2D.IgnoreLayerCollision(6, 9, false); 
        SwordGO.GetComponent<Rigidbody2D>().gravityScale = 0;
        SwordGO.transform.position = Startpos;
        SwordGO.CanTake = false;
        SwordGO.gameObject.layer = 10;
        SwordGO.gameObject.SetActive(true);
        // SwordGO.GetComponent<Rigidbody2D>().velocity = Endpos*BulletSpeed;
        SwordGO.vel = (Endpos-Startpos).normalized*BulletSpeed;
        print("EndPos "+ SwordGO.vel);
      //  print(Endpos);
        
        // SwordGO.GetComponent<Rigidbody2D>().AddForce(Endpos.normalized*BulletSpeed, ForceMode2D.Impulse);
        SwordGO.StartAttack();
        SwordGO.GetComponent<Rigidbody2D>().freezeRotation = false;

        //  SwordGO.GetComponent<Rigidbody2D>().AddForce(pos * BulletSpeed);
        /*
         if (Endpos.x >= 0 && Endpos.y >= 0)
         {
             SwordGO.transform.rotation = Quaternion.Euler(0, 0,270-Vector3.Angle(new Vector3(Endpos.x, Endpos.y, 0), new Vector3(Startpos.x-1, Startpos.y, 0)));
         }
         else if (Endpos.x <= 0 && Endpos.y <= 0)
         {
             SwordGO.transform.rotation = Quaternion.Euler(0, 0, -90 + Vector3.Angle(new Vector3(Endpos.x, Endpos.y, 0), new Vector3(Startpos.x-1, Startpos.y, 0)));
         }
         else if (Endpos.x >= 0 && Endpos.y <= 0)
         {
             SwordGO.transform.rotation = Quaternion.Euler(0, 0, -90+ Vector3.Angle(new Vector3(Endpos.x, Endpos.y, 0), new Vector3(Startpos.x-1, Startpos.y, 0)));
         }
         else if (Endpos.x <= 0 && Endpos.y >= 0)
         {
             SwordGO.transform.rotation = Quaternion.Euler(0, 0, 270- Vector3.Angle(new Vector3(Endpos.x, Endpos.y, 0), new Vector3(Startpos.x-1, Startpos.y, 0)));
         }
         */
        if(Endpos.x - Startpos.x > 0)
        {
            SwordGO.transform.rotation = Quaternion.Euler(0, 0, Vector3.Angle((Endpos - Startpos), new Vector3(0, -1, 0)));
        }
        else
        {
            SwordGO.transform.rotation = Quaternion.Euler(0, 0, -Vector3.Angle((Endpos - Startpos), new Vector3(0, -1, 0)));
        }
       // SwordGO.transform.rotation = Quaternion.Euler(0, 0, 0);
    }

}
