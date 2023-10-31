// References:
//  HOW TO MAKE CHECKPOINTS IN UNITY - EASY TUTORIAL by Blackthornprod - https://www.youtube.com/watch?v=ofCLJsSUom0
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    private CheckpointManager checkMng;

    private void Start()
    {
        checkMng = GameObject.FindGameObjectWithTag("CheckMNG").GetComponent<CheckpointManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            checkMng.lastCheckpointPos = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        }
    }
}
