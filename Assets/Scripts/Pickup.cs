using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.TextCore.Text;
using UnityEngine.UI;

public class Pickup : MonoBehaviour
{
    private GameObject baryonyx;

    void Awake()
    {
        baryonyx = GameObject.Find("Baryonyx");
    }

    void Update()
    {
        float distance = Vector3.Distance(baryonyx.transform.position, this.transform.position); //returns magnitude basically after subtracting baryonyx pos by this class' pos

        if (distance <= 2.5)
        {
            transform.Translate(Vector3.up * 1.0f);
            this.gameObject.SetActive(false);
        }
    }
}
