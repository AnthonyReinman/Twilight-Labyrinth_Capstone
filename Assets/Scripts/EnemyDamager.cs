using UnityEngine;

public class EnemyDamager : MonoBehaviour
{
    public float damageAmount;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
           collision.GetComponent<EnemyMovement>().TakeDamage(damageAmount);
        }
    }

}
