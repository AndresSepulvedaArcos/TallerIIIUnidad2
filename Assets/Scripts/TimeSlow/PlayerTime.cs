using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTime : MonoBehaviour
{
    Rigidbody2D rb;

    public delegate void FNotifyChangeTime(bool bHasTimeSlow);
    public static event FNotifyChangeTime OnTimeChange;

    public float moveSpeed = 2;

    public bool timeShift;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void ChangeTime()
    {
        //timeShift es true cuando el tiempo esta lento y es false cuando el tiempo es normal
        if(timeShift==false)
        {
            timeShift = true;
            OnTimeChange?.Invoke(timeShift);
            return;
        }

        if (timeShift == true)
        {
            timeShift = false;
            OnTimeChange?.Invoke(timeShift);
            return;
        }
    }

    void MovePlayer()
    {
        float x = Input.GetAxis("Horizontal");


        rb.velocity = Vector2.right * x * moveSpeed;//+ Vector2.down * rb.velocity.y;


    }
    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Fire2"))
        {
            ChangeTime();
        }

        MovePlayer();



    }
}
