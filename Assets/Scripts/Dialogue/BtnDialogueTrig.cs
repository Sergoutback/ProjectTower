using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BtnDialogueTrig : MonoBehaviour
{
    public Dialogue[] dialogue;
    [SerializeField]private int Ndialogues=0;
    public int alldialogues;

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            
            if (alldialogues-1 >= Ndialogues)
            {
                FindObjectOfType<DialogueManager>().StartDialogue(dialogue[Ndialogues]);
                Ndialogues++;
            }
            else
            {
                gameObject.SetActive(false);
            }
        }
        
    }


}

