using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutOfBounds : MonoBehaviour
{
    private float _topBound = 30;
    private float _lowerBound = -10;
    private float _sideBound = 35;
    private GameManager _gameManager;
    
    void Start()
    {
        _gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }
    
    void Update()
    {
        if(transform.position.z > _topBound)
        {
            Destroy(gameObject);
        }
        
        if(transform.position.z < _lowerBound)
        {
            Destroy(gameObject);
            _gameManager.AddLives(-1);
        }
        
        if (transform.position.x < -_sideBound)
        {
            Destroy(gameObject);
            _gameManager.AddLives(-1);
        }

        if (transform.position.x > _sideBound)
        {
            Destroy(gameObject);
            _gameManager.AddLives(-1);
        }
    }
}
