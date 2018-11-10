using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Net;
using System.IO;
using System.Net.Sockets;
using System.Threading;

public class PisonClient
{
    private TcpClient client;
    private StreamReader reader;
    private StreamWriter writer;
    PisonFrameReceiver receiver;
    private Thread curThread;
    public bool running = true;

    private const string hapticBuzzTemplate = "{\"durationMs\":!!,\"intensity\":100,\"type\":\"HAPTICBUZZ\"}";

    public PisonClient(int port, PisonFrameReceiver receiver)
    {
        Debug.Log("Waiting for connection...");
        client = new TcpClient("localhost", port);
        NetworkStream stream = client.GetStream();
        reader = new StreamReader(stream);
        writer = new StreamWriter(stream);
        writer.AutoFlush = true;
        Debug.Log("Connected!");
        this.receiver = receiver; 
        curThread = new Thread(receiveFrame);
        curThread.Start();
    }

    public void sendHaptic(short ms)
    {
        string toSend = String.Copy(hapticBuzzTemplate);
        toSend = toSend.Replace("!!", ms.ToString());
        writer.WriteLine(toSend);
    }

    private void receiveFrame()
    {
        while(running)
        {
            var curLine = reader.ReadLine();
            var curFrame = PisonFrame.CreateFromJSON(curLine);
            receiver.receiveFrame(curFrame);
            Thread.Sleep(1);
        }
    }

    private PisonFrame[] LinesToFrames(string[] lines)
    {
        var result = new PisonFrame[lines.Length];
        for(int i = 0; i < lines.Length; i++)
        {
            var curLine = lines[i];
            var curFrame = PisonFrame.CreateFromJSON(curLine);
            result[i] = curFrame;
        }
        return result;
    }

    public void dispose()
    {
        running = false;
        client.Close();
    }

    public interface PisonFrameReceiver
    {
        void receiveFrame(PisonFrame frame);
    }
}
