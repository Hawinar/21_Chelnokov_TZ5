using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class BlockController : MonoBehaviour
{
    [SerializeField] private List<BlockType> blockTypes = new List<BlockType>();
    [SerializeField] private PolygonCollider2D _collider;
    [SerializeField] private Rigidbody2D _rb2D;

    [SerializeField] private SpriteRenderer _spriteRenderer;

    private bool isLast;
    void Start()
    {
        
        _rb2D.isKinematic = true;
        int rnd = UnityEngine.Random.Range(0, blockTypes.Count);
        _collider.points = blockTypes[rnd].points;
        _spriteRenderer.sprite = blockTypes[rnd].sprite;
        _rb2D.gravityScale = 1;
        isLast = true;
        GameController.Moved = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnMouseDrag()
    {
        if (isLast)
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            _rb2D.position = new Vector2(mousePosition.x, mousePosition.y);
        }

    }
    private void OnMouseUp()
    {
        if (isLast)
        {
            _rb2D.isKinematic = false;
            StartCoroutine(CheckY());
            isLast = false;
            GameController.Moved = true;
        }
    }

    [Serializable]
    public class BlockType
    {
        public Sprite sprite;
        public Vector2[] points;
    }
    IEnumerator CheckY()
    {
        yield return new WaitForSeconds(2);
        if (_rb2D.transform.localPosition.y > GameController.LastY)
        {
            GameController.LastY = _rb2D.transform.localPosition.y;
            GameController.Score = GameController.LastY + 4.45f;
        }
        else
        {
            Debug.Log("Поражение");
            GameController.isWinning = false;
        }
    }
}
