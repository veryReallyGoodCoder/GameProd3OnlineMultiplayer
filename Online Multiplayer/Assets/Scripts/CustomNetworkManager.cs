using UnityEngine;
using Mirror;

public class CustomNetworkManager : NetworkManager
{
    public GameObject player1Prefab;
    public GameObject player2Prefab;

    public override void OnServerAddPlayer(NetworkConnectionToClient conn)
    {

        Debug.Log("OnServerAddPlayer method called");

        GameObject playerInstance;

        if(conn.connectionId == 0)
        {
            playerInstance = Instantiate(player1Prefab, Vector3.zero, Quaternion.identity);
            Debug.Log(conn.connectionId);
        }

        else
        {
            playerInstance = Instantiate(player2Prefab, Vector3.zero, Quaternion.identity);
        }

        NetworkServer.AddPlayerForConnection(conn, playerInstance);
    }
}
