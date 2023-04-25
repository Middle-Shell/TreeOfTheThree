using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Spine;
using Spine.Unity;

public class AnimControllerPlayer : MonoBehaviour
{
    [SerializeField] private SkeletonAnimation _skeletonAnimation;
    
    public void PlayAnimation(string animationName, bool loop = true)
    {
        _skeletonAnimation.state.SetAnimation(0, animationName, loop);
    }
}
