using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public static ObjectPool Instance { get; private set; }
    [SerializeField] private GameObject chefPrefab;
    private List<GameObject> pooledChefs = new List<GameObject>();
    private int maxChefPool = 5;
    [SerializeField] private GameObject customerPrefab;
    private List<GameObject> pooledCustomers = new List<GameObject>();
    private int maxChefCustomer = 6;




    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    void Start()
    {
        for(int i = 0; i< maxChefPool; i++){
            GameObject obj = Instantiate(chefPrefab);
            obj.SetActive(false);
            pooledChefs.Add(obj);
        }
        for(int i = 0; i< maxChefCustomer; i++){
            GameObject obj = Instantiate(customerPrefab);
            obj.SetActive(false);
            pooledCustomers.Add(obj);
        }
    }
    public GameObject GetPooledChef(){
        for(int i = 0; i< pooledChefs.Count; i++){
            if(!pooledChefs[i].activeInHierarchy){
                return pooledChefs[i];
            }
        }
        return null;
    }
    public GameObject GetPooledCustomer(){
        for(int i = 0; i< pooledCustomers.Count; i++){
            if(!pooledCustomers[i].activeInHierarchy){
                return pooledCustomers[i];
            }
        }
        return null;
    }




}
