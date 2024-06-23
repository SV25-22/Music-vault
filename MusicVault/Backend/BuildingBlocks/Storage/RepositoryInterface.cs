using System.Collections.Generic;

namespace MusicVault.Backend.BuildingBlocks.Storage;

public interface IRepositoryInterface<T> {
    public T Add(T entity);
    public T? Update(T entity);
    public T? Get(int id);
    public List<T> GetAll();
}
