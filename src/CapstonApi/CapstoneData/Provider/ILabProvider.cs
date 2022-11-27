using CapstoneData.Model;

namespace CapstoneData.Provider
{
    public interface ILabProvider
    {
        IEnumerable<Lab> GetLabs();
        Lab? GetLabById(int id);
        Lab CreateLab(Lab lab);
        Lab UpdateLabById(int id, Lab lab);
        bool DeleteLabById(int id);
    }
}
