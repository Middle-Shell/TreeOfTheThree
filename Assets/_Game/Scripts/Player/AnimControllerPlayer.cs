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
        print(animationName);
        if (animationName == "run" && _skeletonAnimation.AnimationName == "Jump_down")
        {
            yield return new WaitForSeconds(0.03f);
        }

        if (animationName == "run_to_targeting_transition" && _skeletonAnimation.AnimationName == "run_with_targeting")
        {
            yield return new WaitForSeconds(0.5f);
        }
        _skeletonAnimation.state.SetAnimation(0, animationName, loop);
    }
}
