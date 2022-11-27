using CapstoneData.Model;

namespace CapstoneData.Provider
{
    public interface ILabProvider
    {
        IEnumerable<Lab> GetLabs();
        Lab? GetLabById(int id);
        Lab CreateLab(LabDbo lab);
        Lab UpdateLabById(int id, LabDbo lab);
        bool DeleteLabById(int id);
    }
}
