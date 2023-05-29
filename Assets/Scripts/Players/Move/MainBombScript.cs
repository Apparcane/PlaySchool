using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainBombScript : MonoBehaviour
{

    public float ÑountdownTime = 20f;  // Âğåìÿ îáğàòíîãî îòñ÷åòà â ñåêóíäàõ
    private float ÑurrentTime;        // Òåêóùåå âğåìÿ
    public Text TimerText;

    public GameObject BigBadaBoom; // Ïğåôàá îáúåêòà, êîòîğûé íóæíî çàñïàâíèòü
    public float spawnDelay = 2f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            transform.SetParent(other.transform);
            transform.localPosition = new Vector3(0f, 2f, 0f);
            Debug.Log("aboba");
        }
    }
     
    // Start is called before the first frame update
    void Start()
    {

        TimerText = GameObject.Find("TimerText").GetComponent<Text>();
        ÑurrentTime = ÑountdownTime;
        TimerText.text = "Timer: " + Mathf.RoundToInt(ÑurrentTime);

    }

    // Update is called once per frame
    void Update()
    {
        if (transform.parent != null)
        {
            if (ÑurrentTime >= 0)
            {
                ÑurrentTime -= Time.deltaTime;
                TimerText.text = "Timer: " + Mathf.RoundToInt(ÑurrentTime);
                Debug.Log("Timer: " + Mathf.RoundToInt(ÑurrentTime));
            }
            else
            {
                GameObject looser = transform.parent.gameObject;
                transform.SetParent(null);

                Destroy(looser);

                Instantiate(BigBadaBoom, transform.position, Quaternion.identity);

                transform.localPosition = new Vector3(0f, 1f, 0f);

                Destroy(BigBadaBoom, spawnDelay);

                ÑurrentTime = ÑountdownTime;
            }
        }
    }
}
