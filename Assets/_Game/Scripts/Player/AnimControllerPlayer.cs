using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Spine;
using Spine.Unity;

public class AnimControllerPlayer : MonoBehaviour
{
    [SerializeField] private SkeletonAnimation _skeletonAnimation;
    
    public IEnumerator PlayAnimation(string animationName, bool loop = true)
    {
        //print(_skeletonAnimation.AnimationName);
        if (animationName == "run" && _skeletonAnimation.AnimationName == "Jump_down")
        {
            yield return new WaitForSeconds(0.03f);
        }
        _skeletonAnimation.state.SetAnimation(0, animationName, loop);
    }
}
