using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotShoots : MonoBehaviour
{
    [SerializeField] private GameObject _wrench;
    [SerializeField] private float _speed;
    [SerializeField] private float _distance;
    [SerializeField] private float _reghargingTime;

    private bool _wrenchDie;


    private void InstantiateWrench()
    {
        _wrench = Instantiate(_wrench, new Vector3(-9, 20, 0), Quaternion.identity);
        _wrenchDie = false;
    }
    

    
    private void Start()
    {
        InstantiateWrench();

        //InvokeRepeating("InstantiateWrench", _reghargingTime, _reghargingTime);
    }

    private void Update()
    {
        while (_wrenchDie == false)
        {
            _wrench.transform.Translate(_speed * Time.deltaTime, 0, 0);
        }


        if (_wrench.transform.position.x >= _distance && _wrenchDie == false)
        {
            Destroy(_wrench);

            _wrenchDie = true;

            InvokeRepeating("InstantiateWrench", _reghargingTime, _reghargingTime);
        }

        //StartCoroutine(RobotWrenchShoots());
        //Invoke("InstantiateWrench", _reghargingTime);
        //InstantiateWrench();

        //StartCoroutine(RobotWrenchShoots());

        //private void WrenchShoots()
        //{ 
        //    if (_wrench.transform.position.x >= _distance)
        //    {
        //        Destroy(_wrench);

        //        //_wrenchDie = true;

        //        StartCoroutine(RobotWrenchShoots());

        //        //_wrench = Instantiate<GameObject>(_wrench, transform.position, Quaternion.Euler(90f, 0f, 0f));
        //    }
        //}

        //private IEnumerator RobotWrenchShoots()
        //{
        //    var waitForSeconds = new WaitForSeconds(_reghargingTime);

        //    yield return waitForSeconds; 
        //}

    }
}