using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DialogueEditor;

public class ConvoStarter : MonoBehaviour
{

    public NPCConversation myConversation;
    // Start is called before the first frame update


    public void startconvo()
    {
        ConversationManager.Instance.StartConversation(myConversation);
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
