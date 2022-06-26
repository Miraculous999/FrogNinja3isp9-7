using UnityEngine;

public class HealthCollector : MonoBehaviour
{
    [SerializeField] private float healthValue;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            collision.GetComponent<HealthSystem>().AddHealth(healthValue);
            gameObject.SetActive(false);
        }
    }
}
