using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmStronger : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void GiveBomb()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Transform ArmObject = transform;
            Transform parentObject = ArmObject.parent;
            Transform BombObject = parentObject.Find("Bomb");

            BombObject.SetParent(other.transform);
            BombObject.localPosition = new Vector3(0f, 2f, 0f);
            Debug.Log("aboba3");
        }
    }
}
