using System;
using System.Collections.Generic;
using System.IO;

namespace SwinAdventure;

public abstract class GameObject : IdentifiableObject
{
    private string _description;
    private string _name;

    public GameObject(string[] ids, string name, string desc) : base(ids)
    {
        _name = name;
        _description = desc;
    }

    public string Name
    {
        get { return _name; }
    }

    public virtual string ShortDescription
    {
        get { return _name + " (" + FirstId + ")"; }
    }

    public virtual string FullDescription
    {
        get { return _description; }
    }

    // SaveToFile method
    public virtual void SaveTo(StreamWriter writer)
    {
        writer.WriteLine(_name);
        writer.WriteLine(_description);
    }

    // LoadFromFile method
    public virtual void LoadFrom(StreamReader reader)
    {
        _name = reader.ReadLine() ?? "";
        _description = reader.ReadLine() ?? "";
    }
}