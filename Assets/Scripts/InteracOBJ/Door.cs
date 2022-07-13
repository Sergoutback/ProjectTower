using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Door : MonoBehaviour
{
    public GameObject gameObjectPlayer;
    
    public Vector3 currentFloorPoition;

    [SerializeField] private List<GameObject> AllEnemies = new List<GameObject>(0);

    [SerializeField] private AudioSource soundPlay;

    [SerializeField] public GameObject door;

    [SerializeField] public Sprite doorOpen;

    [SerializeField] public Sprite doorClose;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (collision.GetComponent<PlayerInventory>().HasKey)
            {
                Debug.Log("collision.GetComponent<PlayerInventory>().HasKey");

                NextFloor();
            }
        }
    }

    private void NextFloor()
    {
        soundPlay = GetComponent<AudioSource>();

        soundPlay.Play();

        StartCoroutine(WaitForSeconds());

    }

    IEnumerator WaitForSeconds()
    {
        door.GetComponent<SpriteRenderer>().sprite = doorOpen;

        yield return new WaitForSeconds(0.5f);

        Vector3 newPlayerPosition = new Vector3(11.0f, 9.0f, 0.0f);

        gameObjectPlayer.transform.position += newPlayerPosition;

        door.GetComponent<SpriteRenderer>().sprite = doorClose;

    }
}
