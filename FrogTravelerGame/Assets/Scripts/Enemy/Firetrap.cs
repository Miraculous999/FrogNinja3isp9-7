using System.Collections;
using UnityEngine;

public class Firetrap : MonoBehaviour
{
    [SerializeField] private float damage;

    [Header("Firetrap Timers")]
    [SerializeField] private float activationDelay;
    [SerializeField] private float activeTime;

    private Animator anim;
    private SpriteRenderer spriteRenderer;

    private bool isTriggered,
                 isActive;

    private void Awake()
    {
       anim = GetComponent<Animator>();
       spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (!isTriggered)
                StartCoroutine(ActivateFiretrap());

            if (isActive)
                collision.GetComponent<HealthSystem>().TakeDamage(damage);
        }
    }

    private IEnumerator ActivateFiretrap()
    {
        // Turn the sprite red to notify the player and trigger the trap
        isTriggered = true;
        spriteRenderer.color = Color.red;

        //Wait for delay, activate trap, turn on animation, return color back to normal
        yield return new WaitForSeconds(activationDelay);
        spriteRenderer.color = Color.white; //turn the sprite back to its initial color
        isActive = true;
        anim.SetBool("activated", true);

        //Wait until X seconds, deactivate trap and reset all variables and animator
        yield return new WaitForSeconds(activeTime);
        isActive = false;
        isTriggered = false;
        anim.SetBool("activated", false);
    }
}
