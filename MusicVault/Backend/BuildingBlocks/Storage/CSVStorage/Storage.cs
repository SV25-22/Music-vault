using MusicVault.Backend.BuildingBlocks.Storage.CSVStorage.Serialization;
using System.Collections.Generic;
using System.IO;

namespace MusicVault.Backend.BuildingBlocks.Storage.CSVStorage;

public class Storage<T> where T : ISerializable, new() {
    private readonly string _fileName = @"../../../Data/{0}";
    private readonly CSVSerializer<T> _serializer = new();

    public Storage(string fileName) {
        _fileName = string.Format(_fileName, fileName);
    }

    public List<T> Load() {
        if (!File.Exists(_fileName)) {
            FileStream fs = File.Create(_fileName);
            fs.Close();
        }

        IEnumerable<string> lines = File.ReadLines(_fileName);
        List<T> objects = _serializer.LoadCollection(lines);

        return objects;
    }

    public void Save(List<T> objects) {
        string serializedObjects = _serializer.SaveCollection(objects);
        using StreamWriter streamWriter = new(_fileName);
        streamWriter.Write(serializedObjects);
    }
}