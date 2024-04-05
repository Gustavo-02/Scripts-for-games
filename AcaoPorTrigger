using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Trigger : MonoBehaviour
{
    public bool UmaVez;
    public UnityEvent Acao;

    void Update(){}

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            Acao.Invoke();
            if(UmaVez)
            {
                BoxCollider boxColliders = GetComponent<BoxCollider>();
                boxColliders.enabled = false;
            }
        }
    }
}
