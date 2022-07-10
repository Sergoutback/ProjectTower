using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{
    public bool IsTalking=false;

    public Text dialogueText;
    public Text nameText;

   // private PlayerContr PlayerScr;

    public GameObject DBanner;


    private Queue<string> sentences;

    public Joystick joystick;

    private void Start()
    {
    //    PlayerScr = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerContr>();
        sentences = new Queue<string>();
        DBanner.SetActive(false);
    }

    public void StartDialogue(Dialogue dialogue)
    {
        IsTalking = true;
        joystick.DeadZone = 50;
      //  PlayerScr.StartDialogue();
        StartCoroutine(StartDialogue2(dialogue));
       
    }
    IEnumerator StartDialogue2(Dialogue dialogue)
    {
       
        yield return new WaitForSeconds(1f);
    //    FindObjectOfType<MenuScript>().StartDialogue();
        // GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>().velocity = new Vector2(0f, GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>().velocity.y);
        DBanner.SetActive(true);
        nameText.text = dialogue.name;
        sentences.Clear();

        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }
        DisplayNextSentence();
    }
    public void DisplayNextSentence()
    {
        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }
        string sentence = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }

    IEnumerator TypeSentence(string sentence)
    {
        dialogueText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            yield return new WaitForSeconds(0.05f);
            dialogueText.text += letter;
           
        }
    }

    public void EndDialogue()
    {
        IsTalking = false;
        joystick.DeadZone = 0;

       // PlayerScr.EndDialogue();
      //  FindObjectOfType<MenuScript>().EndDialogue();
        DBanner.SetActive(false);
    }
}