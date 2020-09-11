using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class Photon_Lobby : MonoBehaviourPunCallbacks
{
    public static Photon_Lobby lobby;
    public GameObject battleButton;
    public GameObject cancelButton;

    private void Awake()
    {
        lobby = this; //Creates the singleton, lives withing the Main Menu Scene.    
    }
    // Start is called before the first frame update
    void Start()
    {
        PhotonNetwork.ConnectUsingSettings(); //Connects to Master Photon server.
    }

    public override void OnConnectedToMaster()
    {
        Debug.Log("Player has connected to the Photon Master Server");
        PhotonNetwork.AutomaticallySyncScene = true;
        battleButton.SetActive(true);
    }

    public void OnBattleButtonClicked()
    {
        battleButton.SetActive(false);
        cancelButton.SetActive(true);
        PhotonNetwork.JoinRandomRoom();
    }

    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        Debug.Log("No random room available");
        CreateRoom();
    }

    public override void OnCreateRoomFailed(short returnCode, string message)
    {
        Debug.Log("Failed to create room");
        CreateRoom();

    }

    public void OnCancelButtonClick()
    {
        Debug.Log("Battle Button Clicked");
        cancelButton.SetActive(false);
        battleButton.SetActive(true);
        PhotonNetwork.LeaveRoom();
    }

    public override void OnJoinedRoom()
    {
        Debug.Log("Player has joined a room");
    }

    private void CreateRoom()
    {
        Debug.Log("Trying to create a new room");
        int randomRoomName = Random.Range(0, 10000);
        RoomOptions roomoptions = new RoomOptions() { IsVisible = true, IsOpen = true, MaxPlayers = (byte)Multiplayer_Setting.multiplayerSetting.maxPlayers };
        PhotonNetwork.CreateRoom("Room_ " + randomRoomName, roomoptions);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
