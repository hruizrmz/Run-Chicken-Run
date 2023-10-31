// References:
//  HOW TO MAKE CHECKPOINTS IN UNITY - EASY TUTORIAL by Blackthornprod - https://www.youtube.com/watch?v=ofCLJsSUom0
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointManager : MonoBehaviour
{
    private static CheckpointManager instance;
    public Vector3 lastCheckpointPos;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(instance);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
}
