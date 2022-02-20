using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float horizontalInput;
    [SerializeField] private float verticalInput;
    [SerializeField] private float speed = 10.0f;
    private float xRange = 20;
    private float zUpOutOfBounce = 15;
    private float zDownOutOfBounce = 0;

    public GameObject projectilePrefab;
    public Transform projectileSpawnPoint;
    
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        //вариант с ограничением скорости по диагонали
        Vector3 movement = new Vector3(horizontalInput, 0, verticalInput);
        movement = Vector3.ClampMagnitude(movement, 1);
        transform.Translate(movement * speed * Time.deltaTime);
        
        /*примитивный вариант
        transform.Translate(Vector3.right * horizontalInput * Time.deltaTime * speed);
        transform.Translate(Vector3.forward * verticalInput * Time.deltaTime * speed);
        */

        //keep the player in bounds x
        
        if (transform.position.x< -xRange)
        {transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);}
        
        if(transform.position.x> xRange )
        {transform.position = new Vector3(xRange, transform.position.y, transform.position.z);}
        
        //keep the player in bounds z
        if(transform.position.z> zUpOutOfBounce )
        {transform.position = new Vector3(transform.position.x, transform.position.y, zUpOutOfBounce);}
        
        if(transform.position.z<zDownOutOfBounce )
        {transform.position = new Vector3(transform.position.x, transform.position.y, zDownOutOfBounce);}

        //launch projectile
        if (Input.GetKeyDown(KeyCode.Space))
        {Instantiate(projectilePrefab, projectileSpawnPoint.position, projectilePrefab.transform.rotation);}


    }

}
