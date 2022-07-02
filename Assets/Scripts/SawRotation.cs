using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SawRotation : MonoBehaviour
{
    [SerializeField] private Animation animation;

    private void Update()
    {
        Animation animation = GetComponent<Animation>();
        animation.Play("SawRotation");
    }
}
