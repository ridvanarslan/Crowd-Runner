using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header(" Elements ")] 
    [SerializeField] [Range(1f,10f)] private CrowdSystem crowdSystem;
    
    [Header(" Settings ")] 
    [SerializeField] [Range(1f,10f)] private float moveSpeed;
    
    [Header(" Controls ")]
    [SerializeField] [Range(1f,10f)] private float slideSpeed;

    private Vector2 clickedScreenPosition;
    private Vector3 clickedPlayerPosition;

    void Update()
    {
        Move();
        ManageControl();
    }

    private void ManageControl()
    {
        if (Input.GetMouseButtonDown(0))
        {
            clickedScreenPosition = Input.mousePosition;
            clickedPlayerPosition = transform.position;
        }
        else if (Input.GetMouseButton(0))
        {
            var xScreenDifference = Input.mousePosition.x - clickedScreenPosition.x;
            xScreenDifference /= Screen.width;
            xScreenDifference *= slideSpeed;

            var position = transform.position;
            position.x = clickedPlayerPosition.x + xScreenDifference;
            transform.position = position;
            
        }
    }

    private void Move()
    {
        transform.position += Vector3.forward * moveSpeed* Time.deltaTime;
    }
}
