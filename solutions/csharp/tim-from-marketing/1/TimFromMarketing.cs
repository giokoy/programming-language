using System;

static class Badge
{
    public static string Print(int? id, string name, string? department)
    {
        string deptStr = (department ?? "OWNER").ToUpperInvariant();

        if (id.HasValue)
        {
            return $"[{id}] - {name} - {deptStr}";
        }

        return $"{name} - {deptStr}";
    }
}
