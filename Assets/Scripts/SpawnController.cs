using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnController : MonoBehaviour
{
    [SerializeField] GameObject _block;
    [SerializeField] private float _timeBetweenSpawn;

    private float _spawnTime;

    // Update is called once per frame
    void Update()
    {
        if (Time.time > _spawnTime && GameController.Moved == true)
        {
            Spawn();
            _spawnTime = Time.time + _timeBetweenSpawn;
        }
    }
    private void Spawn()
    {
        List<Quaternion> rotations = new List<Quaternion>() { new Quaternion(0, 0, 0, 1), new Quaternion(0, 0, 0.707106829f, 0.707106829f) }; 
        int rnd = Random.Range(0, rotations.Count);
        Instantiate(_block, new Vector3(6, 2, 0), rotations[rnd]);
    }
}
