using System;
using System.Collections.Generic;
using System.Security.Cryptography;


using UnityEngine;
public class Order : MonoBehaviour
{
    [SerializeField]private MealSO mealSO;
    private Transform table;

    public void CreateOrder(Transform table){
        List<MealSO> mealSOList = OrderManager.Instance.GetMealSOList();
        mealSO = mealSOList[UnityEngine.Random.Range(0, mealSOList.Count)];
        this.table = table;
    }
    public Transform GetTableTransform(){
        return table;
    }
    public MealSO GetOrderMealSO(){
        return mealSO;
    }
}
