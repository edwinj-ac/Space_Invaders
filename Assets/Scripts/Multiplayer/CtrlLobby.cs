using Photon.Pun;
using Photon.Realtime;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CtrlLobby : MonoBehaviourPunCallbacks
{
    
    public TMP_Text txt_Status;

    public GameObject obj_ControlRoom;
    public CtrlSalas _ctrlRooms;

    private string nameRoom, namePlayer;
    public byte capacityRoom;

    void Start()
    {
        _ctrlRooms = obj_ControlRoom.GetComponent<CtrlSalas>();
    }

    // Si la conexión fue establecida
    public override void OnConnectedToMaster()
    {
        // Esto indica que todos los jugadores de la sala usarán la misma el jugador master (el que crea la sala) o Master Client
        PhotonNetwork.AutomaticallySyncScene = true;
        ////////////////////////////////////////////////////////////////////////////////////////////////////

 
        //btnConnectLobby.SetActive(true);
        txt_Status.text = "LOBBY CONNECTED";
        PhotonNetwork.NickName = "Player_Invader_" + Random.Range(0, 1000);
        namePlayer = PhotonNetwork.NickName;
        PlayerPrefs.SetString("Nickname_Game", namePlayer);
        JoinRandomRoom(capacityRoom);
        //JoinLobbyOnClick();
    }

    public void JoinLobbyOnClick()
    {
        
        setNombreJugador();

        PhotonNetwork.JoinLobby(); //Primero trata de unirse a un Lobby
        // Por default que lista las salas actualmente existentes

    }

    public void setNombreJugador()
    {
        string jugador = PlayerPrefs.GetString("Nickname_Game"); 
        PhotonNetwork.NickName = jugador;
        Debug.Log("Nom: " + PhotonNetwork.NickName);
    }



    // Cada vez que se cambia el nombre de la sala se actualiza
    public void setRoomName()
    {
        nameRoom = "Room_Space_Invader_" + Random.Range(0, 1000);
    }

    // Cada vez que se cambia el nombre de la sala se actualiza
    public void setCapacidadSala()
    {
       // capacidadSala = int.Parse(maxSala.text);
    }

    public void CreateRoomOnClick() // Método asociado al botón
    {
        setRoomName();
        txt_Status.text = "CREATTING ROOM...";
        Debug.Log("Creando nueva sala: " + nameRoom);
        RoomOptions optionsRoom = new RoomOptions() { IsVisible = true, IsOpen = true, MaxPlayers = (byte)capacityRoom };
        PhotonNetwork.CreateRoom(nameRoom, optionsRoom); // Creación de una nueva sala
    }

    public override void OnCreateRoomFailed(short returnCode, string message) //si la sala existe
    {
        Debug.Log("Fallo en crear una nueva sala, seguramente ya existe una sala con ese nombre.");
        CreateRoomOnClick();
    }

    public void JoinRandomRoom(byte expectedMaxPlayers)
    {
        txt_Status.text = "SEARCHING RANDOM ROOM...";
        PhotonNetwork.JoinRandomRoom(null, expectedMaxPlayers, MatchmakingMode.FillRoom, TypedLobby.Default, null);
    }
    
    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        txt_Status.text = "FAILED CONNECTING RANDOM ROOM...";
        Debug.Log(message + returnCode);
        Debug.Log(" failed to join random game");
        
        CreateRoomOnClick();
    }

    public void StartGameMultiplayer()
    {
        _ctrlRooms.StartGameOnClick();
    }

   
}
