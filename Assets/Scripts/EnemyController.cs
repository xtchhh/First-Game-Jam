using Unity.VisualScripting;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float EnemySpeed;
    private GameObject baryonyx;
    private GameObject egg;
    public MeshRenderer rex;
    public Transform target;

    private void Awake()
    {
        baryonyx = GameObject.Find("Baryonyx");
        egg = GameObject.Find("Egg");
    }

    void Update()
    {
        Vector3 direction = (baryonyx.transform.position - this.transform.position).normalized;

        if (IsActive())
        {
            rex.enabled = true;
            this.transform.Translate(direction * EnemySpeed * Time.deltaTime);
            //this.transform.rotation = Quaternion.Lerp(baryonyx.transform.rotation, this.transform.rotation, 1f);
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
