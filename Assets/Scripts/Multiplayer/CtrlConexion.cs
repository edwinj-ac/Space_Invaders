using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class CtrlConexion : MonoBehaviourPunCallbacks
{
    [SerializeField]
    private int versionGame;

    void Start()
    {
        PhotonNetwork.GameVersion = versionGame.ToString();
        PhotonNetwork.ConnectUsingSettings();
    }

    public override void OnConnectedToMaster()
    {
        Debug.Log("Conectado al servidor " + PhotonNetwork.CloudRegion);
    }
}

