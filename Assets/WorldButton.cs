
using UnityEngine;
using UnityEngine.EventSystems;// Required when using Event data.
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine.Events;

public class WorldButton : MonoBehaviour
{
    public UnityEvent onClick;
    public void OnMouseDown()
    {
        onClick.Invoke();
    }
}
