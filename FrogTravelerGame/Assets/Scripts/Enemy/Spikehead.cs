using UnityEngine;

public class Spikehead : MonoBehaviour
{
    [SerializeField] private float speed, range;
    [SerializeField] private float checkDelay;
    private Vector3 destination;
    private Vector3[] directions = new Vector3[4];

    private float checkTimer;

    private bool attacking;

    private void Update()
    {
        if (attacking)
            transform.Translate(destination * Time.deltaTime * speed);
        else
        {
            checkTimer += Time.deltaTime;
            if (checkTimer > checkDelay)
            {
                CheckForPlayer();
            }
        }
    }

    private void CheckForPlayer()
    {
        CalculatorDurations();

        // Check if spikehead sees player in all 4 directions
        for (int i = 0; i < directions.Length; i++)
        {
            Debug.DrawRay(transform.position, directions[i], Color.red);
        }
    }

    private void CalculatorDurations()
    {
        directions[0] = transform.right * range; // Right direction
        directions[1] = -transform.right * range; // Left direction
        directions[2] = transform.up * range; // Up direction
        directions[3] = -transform.up * range; // Down direction
    }
}
