using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Door : MonoBehaviour
{
    public GameObject gameObjectPlayer;

    [SerializeField]
    private List<GameObject> AllEnemies = new List<GameObject>(0);

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (collision.GetComponent<PlayerInventory>().HasKey)
            {
                NextFloor();
            }
        }
    }

    private void NextFloor()
    {
        Vector3 newPlayerPosition = new Vector3(1.14f, 13.21f, 0.0f);

        gameObjectPlayer.transform.position = newPlayerPosition;

    }
}
