using UnityEngine;
using System.Collections;

public class RoomManager : Photon.MonoBehaviour {

	void Start ()
	{
		//photonを利用するための初期設定 ロビーを作成して入る？
		PhotonNetwork.ConnectUsingSettings("0.1");
	}

	//PhotonNetwork.ConnectUsingSettingsを行うと呼ばれる
	void OnJoinedLobby()
	{
		//ランダムにルームに入る
		PhotonNetwork.JoinRandomRoom();
	}

	//ランダムにルームに入れなかった
	void OnPhotonRandomJoinFailed()
	{
		//部屋を自分で作って入る
		PhotonNetwork.CreateRoom(null);
	}

	//ルームに入室成功
	void OnJoinedRoom()
	{
		//キャラクター作成
		PlayerMake ();

	}

	void PlayerMake(){
		PhotonNetwork.Instantiate ("Player",Vector3.zero,Quaternion.identity,0);
	}
}
