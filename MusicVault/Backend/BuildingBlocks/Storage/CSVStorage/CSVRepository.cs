using MusicVault.Backend.BuildingBlocks.Storage.CSVStorage.Serialization;
using System.Collections.Generic;

namespace MusicVault.Backend.BuildingBlocks.Storage.CSVStorage;

public class CSVRepository<T> : IRepositoryInterface<T> where T : IDAble, ISerializable, new() {
    private readonly List<T> _data;
    private readonly Storage<T> _storage;

    public CSVRepository(string filename) {
        _storage = new Storage<T>(filename);
        _data = _storage.Load();
    }

    private int GenerateId() {
        if (_data.Count == 0)
            return 0;

        return _data[^1].Id + 1;
    }

    private int GetIndex(int id) {
        return _data.FindIndex(c => c.Id == id);
    }

    public T Add(T entity) {
        entity.Id = GenerateId();
        _data.Add(entity);
        _storage.Save(_data);
        return entity;
    }

    public T? Update(T entity) {
        int foundIndex = GetIndex(entity.Id);
        if (foundIndex == -1)
            return null;

        _data[foundIndex] = entity;
        _storage.Save(_data);
        return entity;

    }

    public List<T> GetAll() {
        return _data;
    }

    public T? Get(int id) {
        return _data.Find(c => c.Id == id);
    }
}
