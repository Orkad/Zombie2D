using UnityEngine;
using System.Collections;
using Orkad;

public static class Data
{

    public static StringRecord PlayerName = new StringRecord("PlayerName", "NoName");

    public static IntRecord GroupMaxPlayer = new IntRecord("GroupMaxPlayer", 4);

    public static StringRecord GroupName = new StringRecord("GroupName", "NoName group");

    public static StringRecord Ip = new StringRecord("IpAdress", "127.0.0.1");
}
