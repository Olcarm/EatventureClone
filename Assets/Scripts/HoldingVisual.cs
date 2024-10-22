using System.Collections.Generic;
using UnityEngine;

public class HoldingVisual : MonoBehaviour
{
    [SerializeField] List<Transform> holdingObjectList;

    private void Start() {
        ClearHoldingObject();
    }
    public void UpdateHoldingObject(MealSO mealSO){
        ClearHoldingObject();
        foreach(Transform holdingObject in holdingObjectList){
            if(holdingObject.name == mealSO.name){
                holdingObject.gameObject.SetActive(true);
            }
        }
    }
    public void ClearHoldingObject(){
        foreach(Transform meal in holdingObjectList){
            meal.gameObject.SetActive(false);
        }
    }

}
