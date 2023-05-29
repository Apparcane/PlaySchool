using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainBombScript : MonoBehaviour
{

    public float �ountdownTime = 20f;  // ����� ��������� ������� � ��������
    private float �urrentTime;        // ������� �����
    public Text TimerText;

    public GameObject BigBadaBoom; // ������ �������, ������� ����� ����������
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
        �urrentTime = �ountdownTime;
        TimerText.text = "Timer: " + Mathf.RoundToInt(�urrentTime);

    }

    // Update is called once per frame
    void Update()
    {
        if (transform.parent != null)
        {
            if (�urrentTime >= 0)
            {
                �urrentTime -= Time.deltaTime;
                TimerText.text = "Timer: " + Mathf.RoundToInt(�urrentTime);
                Debug.Log("Timer: " + Mathf.RoundToInt(�urrentTime));
            }
            else
            {
                GameObject looser = transform.parent.gameObject;
                transform.SetParent(null);

                Destroy(looser);

                Instantiate(BigBadaBoom, transform.position, Quaternion.identity);

                transform.localPosition = new Vector3(0f, 1f, 0f);

                Destroy(BigBadaBoom, spawnDelay);

                �urrentTime = �ountdownTime;
            }
        }
    }
}
