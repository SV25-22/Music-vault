using System.Collections.Generic;
using System.Text;

namespace MusicVault.Backend.BuildingBlocks.Storage.CSVStorage.Serialization;

class CSVSerializer<T> where T : ISerializable, new() {
    private const char Delimiter = '|';

    public string SaveCollection(List<T> objects) {
        StringBuilder sb = new();

        foreach (ISerializable obj in objects) {
            string line = string.Join(Delimiter.ToString(), obj.ToCSV());
            sb.AppendLine(line);
        }

        return sb.ToString();
    }

    public List<T> LoadCollection(IEnumerable<string> lines) {
        List<T> objects = new();

        foreach (string line in lines) {
            string[] csvValues = line.Split(Delimiter);
            T obj = new();
            obj.FromCSV(csvValues);
            objects.Add(obj);
        }

        return objects;
    }
}