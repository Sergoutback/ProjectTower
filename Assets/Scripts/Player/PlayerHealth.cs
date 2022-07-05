using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField]
    private int _hp;
    public int HP { get { return _hp; } }

    private Animator anim;
    private void Start()
    {
        anim = gameObject.GetComponent<Animator>();
    }

    private void TakeDamage(int value)
    {
        if (_hp - value > 0)
        {
            _hp -= value;
            Debug.Log("HP" + _hp);
            //anim.SetTrigger("Hurt");
            ReloadPlayer();
            Debug.Log("ReloadPlayer();");
        }
        else
        {
            DeadBecome();
            Debug.Log("DeadBecome()");
        }
    }

    private void DeadBecome()
    {
        SceneManager.LoadScene(2);

        // anim.SetTrigger("Dead");
    }


    private void OnCollisionEnter2D(Collision2D coll)
    {
        if(coll.gameObject.tag == "Enemy")
        {
            TakeDamage(1);
        }

    }

    public void ReloadPlayer()
    {
        //PlayerBullet.swordTr.SetActive(false);
        //SceneManager.LoadScene(1);

        //gameObject.SetActive(true);

        //gameObject.GetComponent<Sword>().CanTake = true;

        gameObject.transform.position = new Vector3(-1.6f, 6.72f, 0.0f);

        //InHand = false;
    }
}
