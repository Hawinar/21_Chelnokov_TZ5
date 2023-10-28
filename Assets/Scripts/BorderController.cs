using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BorderContrpller : MonoBehaviour
{
    [SerializeField] private Collider2D _collider2D;
    [SerializeField] private GameObject _gameOverUI;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Block") 
        {
            Time.timeScale = 0f;
            _gameOverUI.SetActive(true);
        }
    }
}
