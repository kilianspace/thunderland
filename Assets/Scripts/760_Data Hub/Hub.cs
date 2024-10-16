using System;
using System.Collections.Generic;

public class Hub<T>
{
    private Dictionary<string, ICommunicator<T>> _communicators;

    public Hub()
    {
        _communicators = new Dictionary<string, ICommunicator<T>>();
    }

    // Register each communicator of Manager
    public void RegisterCommunicator(string managerName, ICommunicator<T> communicator)
    {
        _communicators[managerName] = communicator;
    }

    // Transfer a message to Manager
    public void Receive(string targetManager, T message)  // messageの型もTに変更
    {
        if (_communicators.ContainsKey(targetManager))
        {
            _communicators[targetManager].Receive(message);
        }
        else
        {
          Log.ObjectInfo("No communicator found",targetManager,1);
            Console.WriteLine($"No communicator found for {targetManager}");
        }
    }
}
