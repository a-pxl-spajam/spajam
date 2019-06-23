using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.SceneManagement;

public class PhotonLogin : MonoBehaviourPunCallbacks
{

    [SerializeField] private GameObject player;
    private AlphaChanging alphaChanging;

    void Start()
    {
        alphaChanging = GameObject.FindObjectOfType<AlphaChanging>();
        if(alphaChanging.GetIsCreatingRoom()) {
            PhotonNetwork.Instantiate(player.name, Vector3.zero, Quaternion.identity, 0);
        }
    }
}

