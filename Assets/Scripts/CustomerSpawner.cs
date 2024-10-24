using UnityEngine;

public class CustomerSpawner : MonoBehaviour
{
    public static CustomerSpawner Instance { get; private set; }

    private int customerCountMax;
    private int customerCount = 0;
    private Vector3 spawnPosition;
    [SerializeField] private GameObject customerPrefab;
    private float timerMax = .5f;
    private float timer = 0f;
    private void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        spawnPosition = new Vector3(-10, 0, 10);
        customerCountMax = OrderManager.Instance.GetTableCount();
        SpawnCustomer();
    }
    private void Update()
    {
        if (customerCount < customerCountMax)
        {
            if (timer < timerMax)
            {
                timer += Time.deltaTime;
            }
            else
            {
                SpawnCustomer();
                timer = 0f;
            }
            
        }
    }

    private void SpawnCustomer()
    {
        GameObject customer = ObjectPool.Instance.GetPooledCustomer();
        if(customer != null){
            customer.transform.position = spawnPosition;
            customer.SetActive(true);
        }
        customerCount++;
    }
    public void IncreaseCustomerCount(int amount){
        customerCountMax += amount;
    }
    public void CustomerLeft()
    {
        customerCount -= 1;
    }
}
