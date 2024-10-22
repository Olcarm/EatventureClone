using System;
using UnityEngine;

[CreateAssetMenu(fileName = "MealSO", menuName = "Scriptable Objects/MealSO")]
public class MealSO : ScriptableObject
{
    public GameObject mealPrefab;
    public String mealName;
    public int price;

}
