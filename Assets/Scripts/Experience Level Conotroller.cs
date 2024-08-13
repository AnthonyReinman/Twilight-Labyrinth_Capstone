using UnityEngine;

public class ExperienceLevelConotroller : MonoBehaviour
{
    public static ExperienceLevelConotroller instance;

    private void Awake()
    {
        instance = this;
    }

    public int currentExperience;

    public ExpPickup pickup;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void GetExp(int amountToGet)
    {
        currentExperience += amountToGet;
    }

    public void SpawnExp(Vector3 position)
    {
        Instantiate(pickup, position, Quaternion.identity);
        Debug.Log("Spawning XP at position: " + position);
    }
}