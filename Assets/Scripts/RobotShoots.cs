using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotShoots : MonoBehaviour
{
    [SerializeField] private GameObject _wrench;
    [SerializeField] private float _speed;
    [SerializeField] private float _distance;

    //private GameObject newWrench;


    private void WrenchShoots()
    {

        _wrench.transform.Translate(_speed * Time.deltaTime, 0, 0);
        if (_wrench.transform.position.x >= _distance)
        {
            Destroy(_wrench);
            _wrench = Instantiate<GameObject>(_wrench, transform.position, Quaternion.Euler(90f, 0f, 0f));
        }
    }

    private IEnumerator RobotWrenchShoots()
    {
        WrenchShoots();

        yield return new WaitForSeconds(5f); 
    }

    private void Update()

    {
        StartCoroutine(RobotWrenchShoots());
    }
}
