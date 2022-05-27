using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Door : MonoBehaviour
{

    [SerializeField]
    private List<GameObject> AllEnemies = new List<GameObject>(0);

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (collision.GetComponent<PlayerInventory>().HasKey)
            {
                NextLevel();
            }
        }
    }

    private void NextLevel()
    {
        SceneManager.LoadScene(0);
    }
}
