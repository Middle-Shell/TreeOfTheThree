using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateEvent : MonoBehaviour
{
    public delegate void PlayerDeath();

    public static event PlayerDeath PlayerDeathEvent;

    public static void OnPlayerDeath()
    {
        PlayerDeathEvent?.Invoke();
    }
    
    public delegate void PlayerCollectPot();

    public static event PlayerCollectPot PlayerCollectPotEvent;

    public static void OnPlayerCollectPot()
    {
        PlayerCollectPotEvent?.Invoke();
    }

    public delegate void FinishMilestone();

    public static event FinishMilestone FinishMilestoneEvent;

    public static void OnFinishMilestone()
    {
        FinishMilestoneEvent?.Invoke();
    }
}
