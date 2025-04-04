using UnityEngine;
using SharedMemory;
using Plunderludics.UnityHawk;

public class SharedKeyInputBuffer : ISharedBuffer {
    private string _name;
    private CircularBuffer _buffer;
    public SharedKeyInputBuffer(string name) {
        _name = name;
    }

    public void Open() {
        _buffer = new (_name);
    }

    public bool IsOpen() {
        return _buffer != null && _buffer.NodeCount > 0;
    }

    public void Close() {
        _buffer.Close();
        _buffer = null;
    }

    public void Write(InputEvent bie) {
        byte[] serialized = Serialization.Serialize(bie);
        // Debug.Log($"[unity-hawk] Writing buffer: {bie}");
        int amount = _buffer.Write(serialized, timeout: 0);
        if (amount <= 0) {
            Debug.LogWarning("Failed to write key event to shared buffer");
        }
    }
}