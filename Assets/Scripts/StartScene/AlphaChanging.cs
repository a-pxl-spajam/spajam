using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.SceneManagement;

public class AlphaChanging : MonoBehaviourPunCallbacks
{

    [SerializeField] private float changingSpeed;
    [SerializeField] private GameObject selectButtons;
    [SerializeField] private GameObject inputFields;
    [SerializeField] private UnityEngine.UI.Text roomNameText;
    [SerializeField] private GameObject player;
    private UnityEngine.UI.Image logoImage;
    private string roomName;
    private bool isCreatingRoom;

    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
        logoImage = GetComponent<UnityEngine.UI.Image>();
        StartCoroutine(Splash());
    }

    IEnumerator Splash() {
        float alpha = 0;
        while(logoImage.color.a < 1.0f) {
            alpha += Time.deltaTime * changingSpeed;
            logoImage.color = new Color(1.0f, 1.0f, 1.0f, alpha);
            yield return null;
        }
        yield return new WaitForSeconds(1.0f);
        while(logoImage.color.a > 0) {
            alpha -= Time.deltaTime * changingSpeed;
            logoImage.color = new Color(1.0f, 1.0f, 1.0f, alpha);
            yield return null;
        }
        yield return new WaitForSeconds(0.75f);
        selectButtons.SetActive(true);
    }

    public void OnClickedCreateRoom() {
        selectButtons.SetActive(false);
        inputFields.SetActive(true);
        isCreatingRoom = true;
    }

    public void OnClickedJoinRoom() {
        selectButtons.SetActive(false);
        inputFields.SetActive(true);
        isCreatingRoom = false;
    }

    public void OnClickedReturnButton() {
        inputFields.SetActive(false);
        selectButtons.SetActive(true);
    }

    public void OnClickedOKButton() {
        roomName = roomNameText.text;
        inputFields.SetActive(false);
        
        // つくる側
        if(isCreatingRoom) {
            PhotonNetwork.ConnectUsingSettings();
        // 参加する側
        } else {

        }
    }

    // complated connecting master server
    public override void OnConnectedToMaster() {
        PhotonNetwork.JoinOrCreateRoom(roomName, new RoomOptions(), TypedLobby.Default);
    }

    // completed connecting room
    public override void OnJoinedRoom() {
        SceneManager.LoadScene("Editor");
    }

    public bool GetIsCreatingRoom() {
        return isCreatingRoom;
    }
}
