using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class TrapTime : MonoBehaviour
{

    public Transform trap;
    public float time;
    public Vector3 targetPosition;
    public LoopType LoopType = LoopType.Yoyo;


    // Start is called before the first frame update
    void Start()
    {
        MoveTrapToTargetPosition();
        
    }

    private void OnEnable()
    {
        PlayerTime.OnTimeChange += PlayerTime_OnTimeChange;
    }

    private void OnDisable()
    {
        PlayerTime.OnTimeChange -= PlayerTime_OnTimeChange;

    }
    private void PlayerTime_OnTimeChange(bool bHasTimeSlow)
    {
        if(bHasTimeSlow)
        {
            //Debug.LogFormat("times slow for {0}", gameObject.name);
            DOTween.timeScale = 0.2f;
        }else
        {
            DOTween.timeScale = 1f;
        }

    }

    void MoveTrapToTargetPosition()
    { 

        trap.DOLocalMove(targetPosition, time).SetLoops(-1, LoopType);
        

    }

   
}
