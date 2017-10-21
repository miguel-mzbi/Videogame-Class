using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ASymbol {

    private string name;

    public string Name {
        get {
            return name;
        }
    }

    public ASymbol(string name) {
        this.name = name;
    }
}
