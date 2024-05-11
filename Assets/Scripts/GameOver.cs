using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    public void Gameover()
    {
        EdgeGlowVolume eg = VolumeManager.instance.stack.GetComponent<EdgeGlowVolume>();
        eg.Active = new BoolParameter(true, true);
    }
}
