using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommandInvoker : MonoBehaviour
{
    static Queue<ICommand> commandBuffer;

    static public List<ICommand> commandHistory;
    static public int counter;

    private void Awake() 
    {
        commandBuffer = new Queue<ICommand>();
        commandHistory = new List<ICommand>();
    }

    public static void AddCommand(ICommand command)
    {
        while (commandHistory.Count > counter)
        {
            commandHistory.RemoveAt(counter);
        }
       // Debug.Log("CH: " + commandHistory.Count);
        commandBuffer.Enqueue(command);
       // Debug.Log("CB: "+commandBuffer.Count);
    }

    // Update is called once per frame
    void Update()
    {
       // Debug.Log("dude are you serious");

        if (commandBuffer.Count > 0)
        {
            ICommand c = commandBuffer.Dequeue();
            c.Execute();
            
            commandHistory.Add(c);
            counter++;
            //Debug.Log("counnter: "+ counter);

        }

        //else
        //{
        //    if (Input.GetKeyDown(KeyCode.Z))
        //    {
        //        if (counter > 0)
        //        {
        //            counter--;
        //            commandHistory[counter].Undo();
        //        }
        //    }
        //    else if (Input.GetKeyDown(KeyCode.R))
        //    {
        //        if (counter < commandHistory.Count)
        //        {
        //            commandHistory[counter].Execute();
        //            counter++;
        //        }
        //    }
        //}
    }

    public static void UndoCommand()
    {
        if (counter > 0)
        {
            counter--;
            commandHistory[counter].Undo();

        }
    }

}
