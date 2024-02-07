namespace HexagonalArchitecture.Warehouse.Domain.Interfaces;

public interface IBasePort<T>
{
    Task<T> Add(T item);
    Task<T?> Get(string id);
    Task<IEnumerable<T>> GetAll();
    Task<bool> Update(T item);
    Task<bool> Delete(string id);
}