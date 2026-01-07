namespace Server.Application.Dashboard;

public class StatsDto
{
    public int HastaCount { get; set; }
    public int BasvuruCount { get; set; }
    public int PersonelCount { get; set; }
    public int UserCount { get; set; }
    public int RoleCount { get; set; }
    public List<ChartSeries> DataEnterBarChart { get; set; } = new();
}

public class ChartSeries
{
    public string? Name { get; set; }
    public double[]? Data { get; set; }
}
