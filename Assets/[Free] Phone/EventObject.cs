using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventObject : MonoBehaviour
{
    [SerializeField] private GameObject Text;
    public GameObject EventUI;
    private void Update()
    {
        transform.Rotate(Vector3.down * 40 * Time.deltaTime);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Text.SetActive(true);
        }
    }

    //����� - Trigger Ż��� EventUI����
    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Player")
        {
            Text.SetActive(false);
            EventUI.SetActive(false);
        }
    }

    //����� - getText �߰�
    public GameObject getText()
    {
        return Text;
    }

    public GameObject getEventUI()
    {
        return EventUI;
    }
}
