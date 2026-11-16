using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AreaTrigger : MonoBehaviour
{
    //Variables
    [SerializeField]List<string> tagsToDetect = new List<string>() { "Player" };

    //Eventos
    [SerializeField] UnityEvent OnEnterEvent;
    [SerializeField] UnityEvent OnExitEvent;



    private void OnTriggerEnter(Collider other)
    {
        if (tagsToDetect.Contains(other.tag))
        {
            OnEnterEvent.Invoke();
        }   
    }

    private void OnTriggerExit(Collider other)
    {
        if (tagsToDetect.Contains(other.tag))
        {
            OnExitEvent.Invoke();
        }
    }
}
