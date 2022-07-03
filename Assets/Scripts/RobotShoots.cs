using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotShoots : MonoBehaviour
{
    [SerializeField] private GameObject _wrench;
    [SerializeField] private float _speed;
    [SerializeField] private float _distance;
    //[SerializeField] private float _reghargingTime;

    private bool _wrenchDie;


    private void InstantiateWrench()
    {
        _wrench = Instantiate(_wrench, new Vector3(-9, 20, 0), Quaternion.identity);

        _wrenchDie = false;
    }
    
    
    private void Start()
    {
        InstantiateWrench();

        //InvokeRepeating("InstantiateWrench", 5f, 7f);
    }

    private void Update()
    {
        if (_wrenchDie == false)
        {
            _wrench.transform.Translate(_speed * Time.deltaTime, 0, 0);
        }


        if (_wrench.transform.position.x >= _distance)
        {
            Destroy(_wrench);

            _wrenchDie = true;

            InstantiateWrench();
        }
    }
}