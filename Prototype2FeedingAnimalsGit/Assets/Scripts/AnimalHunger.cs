using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnimalHunger : MonoBehaviour
{
    [SerializeField] private Slider hungerSlider;
    [SerializeField] private int amountToBeFed;

    private int _сurrentFedAmount = 0;

    private GameManager _gameManager;
   
    private void Start()
    {
        hungerSlider.maxValue = amountToBeFed;
        hungerSlider.value = 0;
        hungerSlider.fillRect.gameObject.SetActive(false);

        _gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }      

    public void FeedAnimal (int amount)
    {
        _сurrentFedAmount += amount;
        hungerSlider.fillRect.gameObject.SetActive(true);
        hungerSlider.value = _сurrentFedAmount;

        if (_сurrentFedAmount >= amountToBeFed) 
        Destroy(gameObject, 0.1f);
    }
}
