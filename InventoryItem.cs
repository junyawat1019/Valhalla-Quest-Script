using Invector.vCharacterController;
using QuantumTek.QuantumDialogue.Demo;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Item")]
public class InventoryItem : ScriptableObject
{
    new public string name = "New Item";
    public Sprite icon = null;
    public bool showIntenvory = true;

    //คำสั่งกรณีใช้ Item
    public void Use()
    {
        if (name.Equals("Axe"))
        {
            vThirdPersonController.instance.ShowAxe();
            RemoveItemFromInventory();
        }
        if (name.Equals("HpPotion") && PlayerManager.instance.HP < 100)
        {
            PlayerManager.instance.Healing();
            RemoveItemFromInventory();
        }

        if (name.Equals("KeyItem1"))
        {
            QD_DialogueDemo.instance.DialogueUI.SetActive(true);
            QD_DialogueDemo.instance.handler.SetConversation("KeyItem1");
            QD_DialogueDemo.instance.SetText();
            NpcManager.instance.Key1 = true;
        }
        else if (name.Equals("KeyItem2"))
        {
            QD_DialogueDemo.instance.DialogueUI.SetActive(true);
            QD_DialogueDemo.instance.handler.SetConversation("KeyItem2");
            QD_DialogueDemo.instance.SetText();
            NpcManager.instance.Key2 = true;
        }
        else if (name.Equals("KeyItem3"))
        {
            QD_DialogueDemo.instance.DialogueUI.SetActive(true);
            QD_DialogueDemo.instance.handler.SetConversation("KeyItem3");
            QD_DialogueDemo.instance.SetText();
            NpcManager.instance.Key3 = true;
        }
        else if (name.Equals("KeyItem4"))
        {
            QD_DialogueDemo.instance.DialogueUI.SetActive(true);
            QD_DialogueDemo.instance.handler.SetConversation("KeyItem4");
            QD_DialogueDemo.instance.SetText();
            NpcManager.instance.Key4 = true;
        }
        else if (name.Equals("KeyItem5"))
        {
            QD_DialogueDemo.instance.DialogueUI.SetActive(true);
            QD_DialogueDemo.instance.handler.SetConversation("KeyItem5");
            QD_DialogueDemo.instance.SetText();
            NpcManager.instance.Key5 = true;
        }
        else { }
    }
    public void RemoveItemFromInventory()
    {
        Inventory.instance.Remove(this);
    }

}
