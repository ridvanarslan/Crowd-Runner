using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDetection : MonoBehaviour
{
    [Header(" Elements ")] 
    [SerializeField] private CrowdSystem crowdSystem;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Doors>(out var door))
        {
            var bonusAmount = door.GetBonusAmount(this.transform.position.x);
            var bonusType = door.GetBonusType(this.transform.position.x);
            crowdSystem.ApplyBonus(bonusType, bonusAmount);
            door.Disable();
        }
        else if (other.CompareTag("Finish"))
        {
            print("we hit finish.");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    private void DetectDoors()
    {
    }
}