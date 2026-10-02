using System.Text.Json;

namespace Task3.Core;

public abstract class FileRepository<T> : IRepository<T>
{
    private readonly string _filePath;

    protected FileRepository(string filePath)
    {
        _filePath = filePath;

        if (!File.Exists(_filePath))
        {
            File.WriteAllText(_filePath, "[]");
        }
    }

    protected List<T> GetItems()
    {
        string json = File.ReadAllText(_filePath);

        if (string.IsNullOrWhiteSpace(json))
            return new List<T>();

        return JsonSerializer.Deserialize<List<T>>(json)
               ?? new List<T>();
    }

    protected void SaveItems(List<T> items)
    {
        string json = JsonSerializer.Serialize(
            items,
            new JsonSerializerOptions
            {
                WriteIndented = true,
                Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping
            });

        File.WriteAllText(_filePath, json);
    }

    protected abstract int GetId(T item);

    public void Create(T item)
    {
        if (item == null)
            throw new ArgumentNullException(nameof(item));

        var items = GetItems();

        items.Add(item);

        SaveItems(items);
    }

    public T? Read(int id)
    {
        var items = GetItems();

        return items.FirstOrDefault(x => GetId(x) == id);
    }

    public List<T> ReadAll()
    {
        return GetItems();
    }

    public void Update(T item)
    {
        if (item == null)
            throw new ArgumentNullException(nameof(item));

        var items = GetItems();

        int id = GetId(item);

        int index = items.FindIndex(x => GetId(x) == id);

        if (index == -1)
            throw new Exception($"Объект с Id = {id} не найден.");

        items[index] = item;

        SaveItems(items);
    }

    public void Delete(int id)
    {
        var items = GetItems();

        int removedCount = items.RemoveAll(x => GetId(x) == id);

        if (removedCount == 0)
            throw new Exception($"Объект с Id = {id} не найден.");

        SaveItems(items);
    }
}