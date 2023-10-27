using UnityEngine;
using Mirror;

public class CustomNetworkManager : NetworkManager
{
    public GameObject player1Prefab;
    public GameObject player2Prefab;

    public GameObject player1SpawnPoint;
    public GameObject player2SpawnPoint;

    public override void OnServerAddPlayer(NetworkConnectionToClient conn)
    {

        Debug.Log("OnServerAddPlayer method called");

        GameObject playerInstance;

        if(conn.connectionId == 0)
        {
            playerInstance = Instantiate(player1Prefab, player1SpawnPoint.transform.position, Quaternion.identity);
            Debug.Log(conn.connectionId);
        }

        else
        {
            playerInstance = Instantiate(player2Prefab, player2SpawnPoint.transform.position, Quaternion.identity);
        }

        NetworkServer.AddPlayerForConnection(conn, playerInstance);
    }
}
