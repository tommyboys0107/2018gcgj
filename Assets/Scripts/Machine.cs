using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CliffLeeCL;

public abstract class Machine
{
    public enum Type
    {
        Treasure,
        Trap
    }

    public abstract Type type { get; }

    public virtual void Enter()
    {
        //
    }

    static public Machine Create(Type _type)
    {
        Machine newMachine;

        switch (_type)
        {
            case Type.Treasure:
                newMachine = new Treasure(); break;

            case Type.Trap:
                newMachine = new Trap(); break;

            default:
                newMachine = null; break;
        }

        return newMachine;
    }
}

public class Treasure : Machine
{
    public override Type type { get { return Type.Treasure; } }

    public override void Enter()
    {
        base.Enter();

        AudioManager.Instance.PlaySound(AudioManager.AudioName.ItemGet, 0.8F);       //播放音效

        GameManager.instance.itemManager.coin += Random.Range(1,8);                 //隨機獲得魔力
        
        Debug.Log("Treasure !");

        GameManager.instance.mapManager.setMachine(GameManager.instance.charManager.pos, null); //移除這個機關

    }
}

public class Trap : Machine
{
    public override Type type { get { return Type.Trap; } }

    public override void Enter()
    {
        base.Enter();

        AudioManager.Instance.PlaySound(AudioManager.AudioName.PlayerHurt, 0.8F);       //播放音效

        GameManager.instance.charManager.HP -= 10;  //減 10 HP

        Debug.Log("Trap !");

        GameManager.instance.mapManager.setMachine(GameManager.instance.charManager.pos, null); //移除這個機關
    }
}