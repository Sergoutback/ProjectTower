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
            //skeletonAnimation.SetActive(true);
            //Debug.Log("PropsDestroyAnimation PropsAnimation()");
            StartCoroutine(ObjectEnable());
            Debug.Log("PropsDestroyAnimation ObjectEnable()");

            //StartCoroutine(ObjectDisable()); 
            //Debug.Log("PropsDestroyAnimation ObjectDisable()");


            //skeletonAnimation.SetActive(false);
            //Debug.Log("PropsAnimation() skeletonAnimation.SetActive(false)");
        }

        IEnumerator ObjectEnable()
        {
            skeletonAnimation.SetActive(true);
            Debug.Log("IEnumerator ObjectEnable SetActive(true)");
            yield return new WaitForSeconds(1);
            Debug.Log("IEnumerator ObjectEnable WaitSomeSeconds(5f)");
            skeletonAnimation.SetActive(false);
            Debug.Log("IEnumerator SetActive(false) SetActive(false)");
            //skeletonAnimation.SetActive(false);
            //Debug.Log("IEnumerator skeletonAnimation.SetActive(false)");
        }

        //IEnumerator ObjectDisable()
        //{
        //    //skeletonAnimation.SetActive(false);

        //    ////yield return StartCoroutine(ObjectEnable());

        //    ////skeletonAnimation.SetActive(true);
        //    ////Debug.Log("PropsDestroyAnimation PropsAnimation()");
        //    //yield return new WaitForSeconds(5);
        //    ////Debug.Log("IEnumerator WaitSomeSeconds(5f)");
            
        //    //Debug.Log("IEnumerator SetActive(false) SetActive(false)");
        //}
    }
}
