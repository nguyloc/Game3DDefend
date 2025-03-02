using UnityEngine;
using DialogueEditor;

public class NPCSystem : MonoBehaviour
{
    public NPCConversation con;
    bool player_detection = false; // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Detect when player enters the trigger area
    void OnTriggerEnter(Collider other) // Corrected method name to "OnTriggerEnter"
    {
        if (other.CompareTag("Player"))
        {
            player_detection = true;
        }
    }

    // Detect when player exits the trigger area
    private void OnTriggerExit(Collider other){
        player_detection=false;
    }

    // Update is called once per frame
    void Update()
    {
        if (player_detection && Input.GetKeyDown(KeyCode.P))
        {
            Debug.Log("Vao vung noi chuyen");
            ConversationManager.Instance.StartConversation(con);
        }
    }
}
