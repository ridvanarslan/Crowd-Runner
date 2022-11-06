using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header(" Elements ")] 
    [SerializeField] private CrowdSystem crowdSystem;
    [SerializeField] private PlayerAnimator playerAnimator;
    
    [Header(" Settings ")] 
    [SerializeField] [Range(1f,15f)] private float moveSpeed;
    private bool _canMove;
    
    [Header(" Controls ")]
    [SerializeField] [Range(1f,10f)] private float slideSpeed;

    private Vector2 clickedScreenPosition;
    private Vector3 clickedPlayerPosition;

    private void OnEnable() => GameManager.onGameStateChanged += GameStateChangedCallback;
    private void OnDisable() => GameManager.onGameStateChanged -= GameStateChangedCallback;

    void Update()
    {
        if (_canMove)
        {
            Move();
            ManageControl();
        }
    }

    private void StartMoving()
    {
        _canMove = true;
        playerAnimator.Run();
    }
    private void StopMoving()
    {
        _canMove = false;
        playerAnimator.Idle();
    }
    private void GameStateChangedCallback(GameState gameState)
    {
        if (gameState == GameState.Game)
        {
            StartMoving();
        }
        else
        {
            StopMoving();
        }
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
    private void Move() => transform.position += Vector3.forward * moveSpeed* Time.deltaTime;
}
