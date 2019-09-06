using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class LeftAnimator : MonoBehaviour
{
    public SteamVR_Action_Single l_GrabAction = null;
    private Animator m_Animator = null;
    public SteamVR_Behaviour_Pose l_Pose = null;

    private void Awake()
    {
        m_Animator = GetComponent<Animator>();
        l_GrabAction[l_Pose.inputSource].onChange += LGrab;
    }

    private void OnDestroy()
    {
        l_GrabAction[l_Pose.inputSource].onChange -= LGrab;
    }

    private void LGrab(SteamVR_Action_Single action, SteamVR_Input_Sources source, float axis, float delta)
    {
        m_Animator.SetFloat("LPointBlend", axis);
    }
}
