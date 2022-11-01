using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Doors : MonoBehaviour
{
    [Header(" Elements ")] [SerializeField]
    private SpriteRenderer leftDoorRenderer;

    [SerializeField] private SpriteRenderer rightDoorRenderer;
    [SerializeField] private TextMeshPro leftDoorText;
    [SerializeField] private TextMeshPro rightDoorText;

    [Header(" Settings ")] [SerializeField]
    private BonusType leftDoorBonusType;

    [SerializeField] private int leftDoorBonusAmount;

    [SerializeField] private BonusType rightDoorBonusType;
    [SerializeField] private int rightDoorBonusAmount;

    [SerializeField] private Color bonusColor;
    [SerializeField] private Color penaltyColor;


    private void Start()
    {
        // left door
        ConfigureDoors(leftDoorBonusType,leftDoorRenderer,leftDoorBonusAmount,leftDoorText);
        
        //right door
        ConfigureDoors(rightDoorBonusType,rightDoorRenderer,rightDoorBonusAmount,rightDoorText);
    }
    
    private void ConfigureDoors(BonusType bonusType, SpriteRenderer doorRenderer, int amount, TextMeshPro textMeshPro)
    {
        switch (bonusType)
        {
            case BonusType.Addition:
                doorRenderer.color = bonusColor;
                textMeshPro.text = $"+{amount}";
                break;
            case BonusType.Difference:
                doorRenderer.color = penaltyColor;
                textMeshPro.text = $"-{amount}";
                break;
            case BonusType.Multiply:
                doorRenderer.color = bonusColor;
                textMeshPro.text = $"x{amount}";
                break;
                ;
            case BonusType.Division:
                doorRenderer.color = penaltyColor;
                textMeshPro.text = $"/{amount}";
                break;
        }
    }

    // private void ConfigureDoors()
    // {
    //     //left door
    //     switch (leftDoorBonusType)
    //     {
    //         case BonusType.Addition:
    //             leftDoorRenderer.color = bonusColor;
    //             leftDoorText.text = $"+{leftDoorBonusAmount}";
    //             break;
    //         case BonusType.Difference:
    //             leftDoorRenderer.color = penaltyColor;
    //             leftDoorText.text = $"-{leftDoorBonusAmount}";
    //             break;
    //         case BonusType.Multiply:
    //             leftDoorRenderer.color = bonusColor;
    //             leftDoorText.text = $"x{leftDoorBonusAmount}";
    //             break;
    //             ;
    //         case BonusType.Division:
    //             leftDoorRenderer.color = penaltyColor;
    //             leftDoorText.text = $"/{leftDoorBonusAmount}";
    //             break;
    //             ;
    //     }
    //
    //     //right door
    //     switch (rightDoorBonusType)
    //     {
    //         case BonusType.Addition:
    //             rightDoorRenderer.color = bonusColor;
    //             rightDoorText.text = $"+{rightDoorBonusAmount}";
    //             break;
    //         case BonusType.Difference:
    //             rightDoorRenderer.color = penaltyColor;
    //             rightDoorText.text = $"-{rightDoorBonusAmount}";
    //             break;
    //         case BonusType.Multiply:
    //             rightDoorRenderer.color = bonusColor;
    //             rightDoorText.text = $"x{rightDoorBonusAmount}";
    //             break;
    //             ;
    //         case BonusType.Division:
    //             rightDoorRenderer.color = penaltyColor;
    //             rightDoorText.text = $"/{rightDoorBonusAmount}";
    //             break;
    //             ;
    //     }
    // }

    public int GetBonusAmount(float xPosition)
    {
        if (xPosition > 0)
            return rightDoorBonusAmount;
        else
            return leftDoorBonusAmount;
    }

    public BonusType GetBonusType(float xPosition)
    {
        if (xPosition > 0)
            return rightDoorBonusType;
        else
            return leftDoorBonusType;
    }

    public void Disable()
    {
        this.GetComponent<BoxCollider>().enabled = false;
    }
}

public enum BonusType
{
    Addition,
    Difference,
    Multiply,
    Division
}