using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Driver : MonoBehaviour
{
    [SerializeField] private Transform playerTransform;

    [SerializeField] private Slider slider;
    public bool active { get; private set; }



    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (!active) { return; }
        Vector3 newpos = new Vector3(playerTransform.localPosition.x, playerTransform.localPosition.y, -slider.value);
        playerTransform.localPosition = newpos;
    }
    public void EnableDriving(bool enable)
    {
        active = enable;    
    }

    //public void MovePlayerToCenter()
    //{
    //    slider.value = enable;
    //}
}
