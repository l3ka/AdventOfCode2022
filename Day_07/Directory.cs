namespace Day_07;

public class Directory
{
    private readonly string Name;

    private long Size;

    private readonly Directory? Parent;

    private readonly List<Directory> SubDirectories;

    private readonly List<File> Files;

    public Directory(string name, long size, Directory? parent = null)
    {
        Name = name;
        Size = size;
        Parent = parent;
        SubDirectories = new List<Directory>();
        Files = new List<File>();
    }

    public void AddSubDirectory(Directory directory)
    {
        // If directory already exist, skip it
        foreach (var subDirectory in SubDirectories)
        {
            if (subDirectory.Name.Equals(directory.Name))
            {
                return;
            }
        }
        SubDirectories.Add(directory);
    }

    public void AddFile(File file)
    {
        // If file already exist, skip it
        foreach (var item in Files)
        {
            if (item.Name.Equals(file.Name))
            {
                return;
            }
        }

        Files.Add(file);
        UpdateDirectorySize(file.Size);
    }

    public Directory GetSubDirectoryByName(string name)
    {
        foreach (var directory in SubDirectories)
        {
            if (directory.Name.Equals(name))
            {
                return directory;
            }
        }
        throw new KeyNotFoundException(nameof(name));
    }

    public Directory? GetParent()
    {
        return Parent;
    }

    public Directory GetRoot()
    {
        if (Parent is not null)
        {
            return Parent.GetRoot();
        }
        return this;
    }

    public long GetSize()
    {
        return Size;
    }

    public long CalculateSum(long treshold)
    {
        Queue<Directory> directories = new();
        directories.Enqueue(this);
        long sum = 0;

        while (directories.Any())
        {
            Directory directory = directories.Dequeue();
            if (directory.Size <= treshold)
            {
                sum += directory.Size;
            }

            for (int i = 0; i < directory.SubDirectories.Count; ++i)
            {
                directories.Enqueue(directory.SubDirectories[i]);
            }
        }

        return sum;
    }

    public Directory FindDirectoryToDelete(long size)
    {
        Queue<Directory> directories = new();
        directories.Enqueue(this);
        Directory toDelete = this;

        while (directories.Any())
        {
            Directory directory = directories.Dequeue();
            if (directory.Size >= size && directory.Size < toDelete.Size)
            {
                toDelete = directory;
            }

            for (int i = 0; i < directory.SubDirectories.Count; ++i)
            {
                directories.Enqueue(directory.SubDirectories[i]);
            }
        }

        return toDelete;
    }

    private void UpdateDirectorySize(long size)
    {
        Size += size;

        // Update sizes of all Parents directories
        Parent?.UpdateDirectorySize(size);
    }
}

public record File(string Name, long Size);