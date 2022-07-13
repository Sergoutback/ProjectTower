using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Player
{
    public class PlayerHealth : MonoBehaviour
    {
        [SerializeField] private int _hp;

        public Slider slider;

        private Animator anim;
        private Transform p;

        private void Start()
        {
            anim = gameObject.GetComponent<Animator>();
        }

        public void ChangeSlidierValue(int value)
        {
            slider.value = value;
            Debug.Log("slider.value" + slider.value);
        }

        private void TakeDamage(int value)
        {
            if (_hp - value > 0)
            {
                _hp -= value;
                Debug.Log("_hp" + _hp);
                //anim.SetTrigger("Hurt");
                RepeatLevel();
                Debug.Log("ReloadPlayer();");
                ChangeSlidierValue(_hp);

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
            if (coll.gameObject.tag == "Enemy")
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

            gameObject.transform.position = new Vector3(0f, 6.72f, 0.0f);
            
            //InHand = false;
        }

        private void RepeatLevel()
        {
            gameObject.transform.Translate(new Vector3(3.0f, 0.0f, 0.0f));
        }
    }
}
