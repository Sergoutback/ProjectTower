using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Props
{

    public class PropsDestroyAnimation : MonoBehaviour
    {
        [SerializeField] public GameObject skeletonAnimation;



        public void PropsAnimation()
        {
            skeletonAnimation.SetActive(true);
            Debug.Log("PropsDestroyAnimation PropsAnimation()");
            StartCoroutine(WaitSomeSeconds());
            Debug.Log("PropsDestroyAnimation WaitSomeSeconds()");
            //skeletonAnimation.SetActive(false);
        }

        IEnumerator WaitSomeSeconds()
        {
            yield return new WaitForSeconds(5f);
            skeletonAnimation.SetActive(false);
        }
    }
}
