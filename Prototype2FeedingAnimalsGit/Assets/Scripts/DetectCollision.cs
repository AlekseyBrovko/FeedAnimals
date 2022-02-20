using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectCollision : MonoBehaviour
{
    private GameManager _gameManager;

    private void Start()
    {
        _gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            _gameManager.AddLives(-1);
            Destroy(gameObject);
        }
        else if (other.CompareTag ("Animal"))
        {
            other.GetComponent<AnimalHunger>().FeedAnimal(1); 
            Destroy(gameObject);            
        }       
    }
}
