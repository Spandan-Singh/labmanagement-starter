using CapstoneData.Model;

namespace CapstoneData.Provider
{
    public interface IAutherProvider
    {
        IEnumerable<AutherDbo> GetAuthers();
        AutherDbo? GetAutherById(int id);
        AutherDbo CreateAuther(AutherDbo Auther);
        AutherDbo UpdateAutherById(int id, AutherDbo auther);
        bool DeleteAutherById(int id);
    }
}
