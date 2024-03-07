using ContainerToolDB;

namespace Backend.Services;

public class ProductionPlanningService
{
    private readonly ContainerToolDBContext _db;
    public ProductionPlanningService(ContainerToolDBContext db) => _db = db;

    public List<ProductionPlanning> GetAllProdcutionPlannings()
    {
        try
        {
            return _db.ProductionPlannings.ToList();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return new List<ProductionPlanning>();
        }
    }

    public ProductionPlanning? GetProdcutionPlanningsForId(int id)
    {
        try
        {
            return _db.ProductionPlannings.Single(x => x.Id == id);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return null;
        }
    }

    public ProductionPlanning? ApprovePpCs(EditStatusDto approveOrderDto)
    {
        try
        {
            var productionPlanning = _db.ProductionPlannings
                .Single(x => x.Id == approveOrderDto.Id);
            productionPlanning.ApprovedByPpCsTime = DateTime.Now;
            productionPlanning.ApprovedByPpCs = approveOrderDto.Status;
            _db.SaveChanges();
            return productionPlanning;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return null;
        }
    }

    public ProductionPlanning? ApprovePpPp(EditStatusDto approveOrderDto)
    {
        try
        {
            var productionPlanning = _db.ProductionPlannings
                .Single(x => x.Id == approveOrderDto.Id);
            productionPlanning.ApprovedByPpPpTime = DateTime.Now;
            productionPlanning.ApprovedByPpPp = approveOrderDto.Status;
            _db.SaveChanges();
            return productionPlanning;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return null;
        }
    }

    public ProductionPlanning? Post()
    {
        try
        {
            var productionPlanning = new ProductionPlanning
            {
                ApprovedByPpCs = false,
                ApprovedByPpPp = false,
                ApprovedByPpCsTime = null,
                ApprovedByPpPpTime = null
            };
            _db.ProductionPlannings.Add(productionPlanning);
            _db.SaveChanges();
            return productionPlanning;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return null;
        }
    }
}
