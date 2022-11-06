using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class CrowdSystem : MonoBehaviour
{
    [Header(" Elements ")]
    [SerializeField] private PlayerAnimator playerAnimator;
    [SerializeField] private Transform runnersParent;
    [SerializeField] private Transform runnersPoolParent;
    [Header(" Settings ")]
    [SerializeField] private float angle;
    [SerializeField] private float radius;

    [Header("Object Pool Settings ")] 
    [SerializeField] private GameObject runnerPrefab;
    [SerializeField] private int maximumRunnerAmount;
    [SerializeField] private List<GameObject> runnerPool;

    private void Start()
    {
        CrowdPool();
        PlaceRunners();
    }
    

    private void PlaceRunners()
    {
        for (int i = 0; i < runnersParent.childCount; i++)
        {
            var childLocalPosition = GetRunnerLocalPosition(i);
            runnersParent.GetChild(i).localPosition = childLocalPosition;
        }
        
    }

    private Vector3 GetRunnerLocalPosition(int index)
    {
        float xPos = radius * Mathf.Sqrt(index) * Mathf.Cos(Mathf.Deg2Rad * index * angle);
        float zPos = radius * Mathf.Sqrt(index) * Mathf.Sin(Mathf.Deg2Rad * index * angle);

        return new Vector3(xPos, 0, zPos);
    }

    public float GetCrowdRadius => radius * Mathf.Sqrt(runnersParent.childCount);
    public void ApplyBonus(BonusType bonusType, int bonusAmount)
    {
        switch (bonusType)
        {
            case BonusType.Addition:
                AddRunners(bonusAmount);
                PlaceRunners();
                CrowdCounter.onCrowdCountChanged?.Invoke(bonusAmount);
                playerAnimator.Run();
                break;
            case BonusType.Difference:
                RemoveRunners(bonusAmount);
                PlaceRunners();
                CrowdCounter.onCrowdCountChanged?.Invoke(bonusAmount * -1);
                break;
            case BonusType.Multiply:
                var runnerToAdd = (runnersParent.childCount * bonusAmount) - runnersParent.childCount;
                AddRunners(runnerToAdd);
                PlaceRunners();
                CrowdCounter.onCrowdCountChanged?.Invoke(runnerToAdd);
                playerAnimator.Run();
                break;
            case BonusType.Division:
                var runnersToRemove = (runnersParent.childCount / bonusAmount);
                RemoveRunners(runnersToRemove);
                PlaceRunners();
                CrowdCounter.onCrowdCountChanged?.Invoke(runnersToRemove);
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(bonusType), bonusType, null);
        }
    }
    private void AddRunners(int amount)
    {
        for (int i = 0; i < amount; i++)
        {
            foreach (var runner in runnerPool.Where(x=> !x.activeInHierarchy))
            {
                runner.transform.SetParent(runnersParent);
                runner.SetActive(true);
                break;
            }
        }

    }
    private void RemoveRunners(int amount)
    {
        if (amount> runnersParent.childCount) amount = runnersParent.childCount;
        for (int i = 0; i < amount; i++)
        {
            foreach (var runner in runnerPool.Where(x=> x.activeInHierarchy))
            {
                runner.SetActive(false);
                runner.transform.SetParent(runnersPoolParent);
                break;
            }
        }
        
    }
    private void CrowdPool()
    {
        for (int i = 0; i < maximumRunnerAmount; i++)
        {
            var runner = Instantiate(runnerPrefab, Vector3.zero, Quaternion.identity, runnersPoolParent);
            runner.SetActive(false);
            runnerPool.Add(runner);
        }
    }
}
