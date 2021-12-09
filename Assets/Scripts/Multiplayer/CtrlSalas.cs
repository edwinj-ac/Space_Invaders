using Photon.Pun;
using Photon.Realtime;
using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class CtrlSalas : MonoBehaviourPunCallbacks
{
    [SerializeField]
    private int indexSceneMultiPlayer;
   
    private string roomName;

    
    public override void OnJoinedRoom()
    {
        PhotonNetwork.LoadLevel(indexSceneMultiPlayer);
        Debug.Log("Ingreso al metodo OnJoinedRoom()");
    }
    
    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        
    }

    public override void OnPlayerLeftRoom(Player otherPlayer)
    {
        
    }

    public void StartGameOnClick()
    {
        if (PhotonNetwork.IsMasterClient)
        {
            PhotonNetwork.CurrentRoom.IsOpen = true;
            PhotonNetwork.LoadLevel(indexSceneMultiPlayer);
        }
    }

    IEnumerator rejoinLobby()
    {
        yield return new WaitForSeconds(2);
        // para forzar la actualización de la lista de salas 
        PhotonNetwork.JoinLobby();
    }




}
