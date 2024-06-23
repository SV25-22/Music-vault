namespace MusicVault.Backend.BuildingBlocks.Storage.CSVStorage.Serialization;

public interface ISerializable {
    string[] ToCSV();

    void FromCSV(string[] values);
}
