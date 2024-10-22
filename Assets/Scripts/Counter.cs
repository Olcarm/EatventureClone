using System;
using Unity.VisualScripting;
using UnityEngine;

public class Counter : MonoBehaviour
{
    [SerializeField] private MealSO mealSO;
    [SerializeField] private float preparationTimeMax;

    [SerializeField] private Transform preparationPosition;
    private float preparationTime;

    private int mealPrice;

    private bool isCounterOccuopied;

    void Start()
    {
        preparationTime = preparationTimeMax;
        isCounterOccuopied = false;
        mealPrice = mealSO.price;
    }

    public MealSO GetCounterMeal(){
        return mealSO;
    }
    public float GetPreparationTime(){
        return preparationTime;
    }
    public void SetPreparationTime(float preparationTime){
        this.preparationTime = preparationTime;
    }
    public Transform GetPreparationPosition(){
        return preparationPosition;
    }
    public void SetCounterOccupied(){
        isCounterOccuopied = !isCounterOccuopied;
    }
    public bool GetCounterIsOccupied(){
        return isCounterOccuopied;
    }
    public void IncreaseMealPrice(){
        mealPrice += 5;
    }
}
