using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Define
{
    private static Player _playerTrm = null;

    public static Player PlayerTrm
    {
        get
        {
            if (_playerTrm == null)
                _playerTrm = GameObject.Find("Player").GetComponent<Player>();
            return _playerTrm;
        }
    }
}
