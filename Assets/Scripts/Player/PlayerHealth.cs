using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField]
    private int HP = 1;
    private Animator anim;
    private void Start()
    {
        anim = gameObject.GetComponent<Animator>();
    }

    private void TakeDamage(int value)
    {
        if (HP - value > 0)
        {
            HP -= value;
            //anim.SetTrigger("Hurt");
            ReloadPlayer();
        }
        else
        {
            DeadBecome();
        }
    }

    private void DeadBecome()
    {
        SceneManager.LoadScene(0);
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
        SceneManager.LoadScene(0);
    }
}
