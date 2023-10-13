using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityHawk;

public class RegisterMethodExample : MonoBehaviour
{
    public Emulator e;
    // Start is called before the first frame update
    void Start()
    {
        e.RegisterMethod("DoSomething", DoSomething);
    }

    private string DoSomething(string arg) {
        char[] charArr = arg.ToCharArray();
        charArr[0] = '_';
        return new string(charArr);
    }
}
