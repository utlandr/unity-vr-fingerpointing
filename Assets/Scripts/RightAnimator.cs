using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class RightAnimator : MonoBehaviour
{
    public SteamVR_Action_Single r_GrabAction = null;
    private Animator m_Animator = null;
    public SteamVR_Behaviour_Pose r_Pose = null;

    private void Awake()
    {
        m_Animator = GetComponent<Animator>();
        r_GrabAction[r_Pose.inputSource].onChange += RGrab;
    }

    private void OnDestroy()
    {
        r_GrabAction[r_Pose.inputSource].onChange -= RGrab;
    }

    private void RGrab(SteamVR_Action_Single action, SteamVR_Input_Sources source, float axis, float delta)
    {
        m_Animator.SetFloat("RPointBlend", axis);
    }
}