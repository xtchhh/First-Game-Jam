using Unity.VisualScripting;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float EnemySpeed;
    private GameObject baryonyx;
    private GameObject egg;
    public MeshRenderer rex;

    private void Awake()
    {
        baryonyx = GameObject.Find("Baryonyx");
        egg = GameObject.Find("Egg");
    }

    void Update()
    {
        Vector3 baryonyxPos = baryonyx.transform.position;
        Vector3 currentPos = this.transform.position;
        Vector3 direction = (baryonyxPos - currentPos).normalized;
        float distance = Vector3.Distance(baryonyxPos, currentPos);

        if (IsActive())
        {
            rex.enabled = true;
            this.transform.Translate(direction * EnemySpeed * Time.deltaTime);

            Quaternion rotation = Quaternion.LookRotation(direction, Vector3.up);
            this.transform.rotation = rotation * Quaternion.Euler(0, 90, 0); //alternates direction??

            if (distance <= 5)
            {
                Debug.Log($"Game over!!");
            }
        }
        Debug.Log(IsActive());
    }

    private bool IsActive()
    {
        if (egg.transform.position.y > 0f)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

}
